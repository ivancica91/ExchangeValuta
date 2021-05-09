using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ZahtjevService : IZahtjevService
    {
        private readonly ExchangeDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public ZahtjevService(ExchangeDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ZahtjevDto> PostZahtjev(PostZahtjevDto postZahtjev)
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

            // pokušavam umjesto id-a raditi s nazivima
            var prodajemValutu = await _context.Sredstva
                .Include(v => v.Valuta)
                //.Where(k => k.KorisnikId == id && k.ValutaId == postZahtjev.ProdajemValutaId)
                .Where(k => k.KorisnikId == id && k.Valuta.Naziv == postZahtjev.ProdajemValuta)
                .FirstOrDefaultAsync();
            if(prodajemValutu == null)
            {
                throw new Exception("Ne posjedujete valutu koju želite prodati.");
            }

            var kupujemValutu = await _context.Valute
                .Where(v => v.Naziv == postZahtjev.KupujemValuta)
                .FirstOrDefaultAsync();

            var kupujemId = kupujemValutu.ValutaId;


            var raspoloziviIznos = _context.Sredstva
                .Include(v => v.Valuta)
                //.Where(k => k.KorisnikId == id && k.ValutaId == postZahtjev.ProdajemValutaId)
                  .Where(k => k.KorisnikId == id && k.Valuta.Naziv == postZahtjev.ProdajemValuta)

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
                //ProdajemValutaId = postZahtjev.ProdajemValutaId,
                //KupujemValutaId = postZahtjev.KupujemValutaId,
                ProdajemValutaId = prodajemValutu.ValutaId,
                KupujemValutaId = kupujemId,
                DatumVrijemeKreiranja = DateTime.Now,
                Prihvacen = 1
            };

            _context.Zahtjevi.Add(zahtjev);

            await _context.SaveChangesAsync();

            return _mapper.Map<ZahtjevDto>(zahtjev);
        }

        public async Task<IEnumerable<ZahtjevDto>> GetAllZahtjeve()
        {
            return await _context.Zahtjevi     
                .Include(v => v.Valuta)
                .ProjectTo<ZahtjevDto>(_mapper.ConfigurationProvider)
                .Select(z => new ZahtjevDto()
                {
                    ZahtjevId = z.ZahtjevId,
                    KorisnikId = z.KorisnikId,
                    ProdajemValutaId = z.ProdajemValutaId,
                    ProdajemValuta = _context.Valute.Where(v => v.ValutaId == z.ProdajemValutaId).Select(s => s.Naziv).FirstOrDefault(),
                    KupujemValutaId = z.KupujemValutaId,
                    KupujemValuta = _context.Valute.Where(v => v.ValutaId == z.KupujemValutaId).Select(s => s.Naziv).FirstOrDefault(),
                    Iznos = z.Iznos,
                    Prihvacen = z.Prihvacen,
                    DatumVrijemeKreiranja = DateTime.Now
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ZahtjevDto>> GetZahtjeveByLoggedUser()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var id = _context.Korisnici.Where(k => k.UserName == userName)
                .FirstOrDefault().Id;

            return await _context.Zahtjevi
                .Include(v => v.Valuta)
                .Where(k => k.KorisnikId == id)
                .ProjectTo<ZahtjevDto>(_mapper.ConfigurationProvider)
                .Select(z => new ZahtjevDto()
                {
                    ZahtjevId = z.ZahtjevId,
                    KorisnikId = z.KorisnikId,
                    ProdajemValutaId = z.ProdajemValutaId,
                    ProdajemValuta = _context.Valute.Where(v => v.ValutaId == z.ProdajemValutaId).Select(s => s.Naziv).FirstOrDefault(),
                    KupujemValutaId = z.KupujemValutaId,
                    KupujemValuta = _context.Valute.Where(v => v.ValutaId == z.KupujemValutaId).Select(s => s.Naziv).FirstOrDefault(),
                    Iznos = z.Iznos,
                    Prihvacen = z.Prihvacen,
                    DatumVrijemeKreiranja = DateTime.Now
                })
                .ToListAsync();

        }


        // NE IZBACUJE MI DOBRE REZULTATE, POGLEDATI JOS MALO TO FILTRIRANJE
        public async Task<IEnumerable<UkupnoProdaneValuteDto>> GetAllOdobreneZahtjeve(DateTime from, DateTime to)
        {
           return await _context.Zahtjevi
                .Where(s => s.Prihvacen == 2 && s.DatumVrijemeKreiranja >= from && s.DatumVrijemeKreiranja <= to)
                .GroupBy(s => s.ProdajemValutaId)
                .Select(s => new UkupnoProdaneValuteDto()
                {
                    ValutaId = s.Key,
                    Naziv = _context.Valute.Where(v => v.ValutaId == s.Key).Select(s => s.Naziv).FirstOrDefault(), // jel ovo super ili cu srusit internet?
                    Iznos = s.Sum(v => v.Iznos),
                }).ToListAsync();
        }

        //public async Task<IEnumerable<ZahtjevDto>> GetProdanoKupljenoOdbijeno(int korisnikId)
        //{
        //    var odobrenizahtjevi = await _context.Zahtjevi
        //        .Where(z => z.KorisnikId == korisnikId && z.Prihvacen == 2)
        //        .GroupBy(v => v.ProdajemValutaId)
        //        .Select(s => new )
        //        .ToListAsync();
        //}


        public async Task<ZahtjevDto> OdobriZahtjev(OdobravanjeZahtjevaDto odobravanjeZahtjeva)
        {

            // trazimo zahtjev po id-u
            var zahtjev = await _context.Zahtjevi
                .Include(v => v.Valuta)
                .Where(z => z.ZahtjevId == odobravanjeZahtjeva.ZahtjevId)
                .ProjectTo<ZahtjevDto>(_mapper.ConfigurationProvider)
                .Select(z => new ZahtjevDto()
                {
                    ZahtjevId = z.ZahtjevId,
                    KorisnikId = z.KorisnikId,
                    ProdajemValutaId = z.ProdajemValutaId,
                    ProdajemValuta = _context.Valute.Where(v => v.ValutaId == z.ProdajemValutaId).Select(s => s.Naziv).FirstOrDefault(),
                    KupujemValutaId = z.KupujemValutaId,
                    KupujemValuta = _context.Valute.Where(v => v.ValutaId == z.KupujemValutaId).Select(s => s.Naziv).FirstOrDefault(),
                    Iznos = z.Iznos,
                    Prihvacen = z.Prihvacen,
                    DatumVrijemeKreiranja = DateTime.Now
                })
                .FirstOrDefaultAsync();

            var httpClient = _httpClientFactory.CreateClient();
            var url = $"https://v6.exchangerate-api.com/v6/09a14a921f6de3a3c311a083/pair/{zahtjev.ProdajemValuta}/{zahtjev.KupujemValuta}/{zahtjev.Iznos}";
            var response = await httpClient.GetAsync(url);
            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<KonverzijaValute>(responseStream);


            // dobijemo period u kojem se ta valuta moze prodati po idu
            var vrijemeProdaje = await _context.Valute
                .Where(v => v.ValutaId == zahtjev.ProdajemValutaId)
                .Select(v => new VrijemeValuteDto()
                {
                    AktivnoOd = v.AktivnoOd,
                    AktivnoDo = v.AktivnoDo
                })
                .FirstOrDefaultAsync();

            //trazimo sva vremena i gledamo da li je moguca prodaja
            TimeSpan start = vrijemeProdaje.AktivnoOd; //10 
            TimeSpan end = vrijemeProdaje.AktivnoDo; //12 
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now < start) && (now > end))
            {
                throw new Exception("Zahtjev se ne može odobriti jer se navedena valuta ne može prodati u ovo doba dana.");
            }

            //// TESTIRAJ
            if (odobravanjeZahtjeva.Prihvacen == 2)
            {
                var prodajnoSredstvo = await _context.Sredstva
                    .Where(u => u.KorisnikId == zahtjev.KorisnikId && u.ValutaId == zahtjev.ProdajemValutaId)
                    .FirstOrDefaultAsync();

                prodajnoSredstvo.Iznos -= zahtjev.Iznos;

                _context.Sredstva.Update(prodajnoSredstvo);
                await _context.SaveChangesAsync();

                var kupovnoSredstvo = await _context.Sredstva
                    .Where(u => u.KorisnikId == zahtjev.KorisnikId && u.ValutaId == zahtjev.KupujemValutaId)
                    .FirstOrDefaultAsync();
                if (kupovnoSredstvo == null)
                {
                    var kupovno = new Sredstva()
                    {
                        ValutaId = zahtjev.KupujemValutaId,
                        KorisnikId = zahtjev.KorisnikId,
                        Iznos = responseObject.conversion_result
                    };
                    _context.Sredstva.Add(kupovno);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    kupovnoSredstvo.Iznos += responseObject.conversion_result;
                    _context.Sredstva.Update(kupovnoSredstvo);
                    await _context.SaveChangesAsync();


                }

                var zah = await _context.Zahtjevi
                    .Where(v => v.ZahtjevId == odobravanjeZahtjeva.ZahtjevId)
                    .FirstOrDefaultAsync();

                zah.Prihvacen = 2;
                zah.DatumVrijemeKreiranja = DateTime.Now;
                _context.Zahtjevi.Update(zah);

                await _context.SaveChangesAsync();
            }

            var odobravanje = new OdobravanjeZahtjevaDto()
            {
                ZahtjevId = odobravanjeZahtjeva.ZahtjevId,
                Prihvacen = odobravanjeZahtjeva.Prihvacen
            };

            var odobreno = _mapper.Map<ZahtjevDto>(odobravanje);

            return odobreno;
        }
    }
}
