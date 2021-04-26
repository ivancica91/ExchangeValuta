using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeValuta.Services
{
    public class SredstvaService : ISredstvaService
    {
        private readonly ExchangeDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public SredstvaService(ExchangeDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<SredstvaDto>> GetSredstvaForLoggedUser()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

           return await _context.Sredstva
                .Where(k => k.KorisnikId == id)
                .ProjectTo<SredstvaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProtuvrijednostDto>> GetProtuvrijednost()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

            var sredstva = await _context.Sredstva
                .Include(v => v.Valuta)
                .Where(k => k.KorisnikId == id)
                .ToListAsync();

            var protuvrijednosti = new List<ProtuvrijednostDto>();
            var httpClient = _httpClientFactory.CreateClient("valute");

            foreach (var sredstvo in sredstva)
            {
                var url = $"09a14a921f6de3a3c311a083/pair/{sredstvo.Valuta.Naziv}/HRK/{sredstvo.Iznos}";
                var response = await httpClient.GetAsync(url);
                var responseStream = await response.Content.ReadAsStreamAsync();
                var responseObject = await JsonSerializer.DeserializeAsync<KonverzijaValute>(responseStream);


                // sve super, samo kako da mi pokazuje brojke u tisucama, sad mi npr 5000 pokazuje kao 5.000
                protuvrijednosti.Add(new ProtuvrijednostDto()
                {
                    Iznos = sredstvo.Iznos,
                    Valuta = sredstvo.Valuta.Naziv,
                    ProtuvrijednostHRK = responseObject.conversion_rate
                });
            }

            return protuvrijednosti;
        }


        public async Task<SredstvaDto> PostSredstva(PostSredstvaDto postSredstva)
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

            var sredstvaaa = await _context.Sredstva
                .Where(s => s.KorisnikId == id)
                .ToListAsync();

            var duplaSredstva = sredstvaaa.Where(v => v.ValutaId == postSredstva.ValutaId).FirstOrDefault();
            if (duplaSredstva != null)
            {
                throw new Exception("Već posjedujete sredstva u traženoj valuti. Molimo Vas ažurirajte iznos tražene valute.");
            }

            if (postSredstva.Iznos == 0)
            {
                throw new Exception("Uneseni iznos ne može biti 0");
            }

            var sredstva = new Sredstva
            {
                KorisnikId = id,
                ValutaId = postSredstva.ValutaId,
                Iznos = postSredstva.Iznos
            };

            

            _context.Sredstva.Add(sredstva);

            await _context.SaveChangesAsync();

            var sredstvaToReturn = _mapper.Map<SredstvaDto>(sredstva);

            return sredstvaToReturn;

        }

        public async Task<SredstvaDto> PutSredstva(PostSredstvaDto postSredstva)
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

            var sredstvaKorisnika = await _context.Sredstva
                .Where(k => k.KorisnikId == id)
                .ToListAsync();

            var sredstvoToPut = sredstvaKorisnika
                .Where(v => v.ValutaId == postSredstva.ValutaId)
                .FirstOrDefault();

            if (sredstvoToPut == null)
            {
                throw new Exception("Ne posjedujete sredstva u traženoj valuti");
            }

            if (postSredstva.Iznos == 0)
            {
                _context.Sredstva.Remove(sredstvoToPut);
                await _context.SaveChangesAsync();
                throw new Exception("Unesena valuta je izbrisana s popisa valuta koje posjedujete");
            }

            // nije bas najelegantnije rješenje, ali radi. nisam uspio grupno nego ovako pojedinacno, mozda vidi kasnije jos
            sredstvoToPut.SredstvaId = sredstvoToPut.SredstvaId;
            sredstvoToPut.KorisnikId = id;
            sredstvoToPut.ValutaId = postSredstva.ValutaId;
            sredstvoToPut.Iznos = postSredstva.Iznos;

            _context.Update(sredstvoToPut);
            await _context.SaveChangesAsync();

            return _mapper.Map<SredstvaDto>(sredstvoToPut);

        }






    }
}
