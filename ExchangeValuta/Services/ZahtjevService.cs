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
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExchangeValuta.Services
{
    public class ZahtjevService : IZahtjevService
    {
        private readonly ExchangeDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ZahtjevService(ExchangeDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ZahtjevDto> PostZahtjev(PostZahtjevDto postZahtjev)
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

            var prodajemValutu = await _context.Sredstva
                .Where(k => k.KorisnikId == id && k.ValutaId == postZahtjev.ProdajemValutaId)
                .FirstOrDefaultAsync();
            if(prodajemValutu == null)
            {
                throw new Exception("Ne posjedujete valutu koju želite prodati.");
            }

            var raspoloziviIznos = _context.Sredstva
                .Where(k => k.KorisnikId == id && k.ValutaId == postZahtjev.ProdajemValutaId)
                .Select(k => new ZahtjevDto()
                {
                    Iznos = k.Iznos
                })
                .FirstOrDefault().Iznos;


            if (postZahtjev.Iznos == 0)
            {
                throw new Exception("Iznos prodaje ne može biti 0");
            }

            if(raspoloziviIznos < postZahtjev.Iznos)
            {
                throw new Exception("Nemate dovoljno sredstava za prodaju");
            }

            var zahtjev = new Zahtjev
            {
                KorisnikId = id,
                Iznos = postZahtjev.Iznos,
                ProdajemValutaId = postZahtjev.ProdajemValutaId,
                KupujemValutaId = postZahtjev.KupujemValutaId,
                DatumVrijemeKreiranja = DateTime.Now,
                Prihvacen = 1
            };

            _context.Zahtjevi.Add(zahtjev);

            await _context.SaveChangesAsync();

            return _mapper.Map<ZahtjevDto>(zahtjev);
        }

        public async Task<IEnumerable<ZahtjevDto>> GetZahtjeve()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

            // TODO
            // ne znam zasto mi nece mapirati imena valuta koje se prodaju/kupuju
            // isto tako u sredstvaService i radi, sve odradio u mapperProfileu
            return await _context.Zahtjevi
                .Where(k => k.KorisnikId == id)
                .ProjectTo<ZahtjevDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

        }


    }
}
