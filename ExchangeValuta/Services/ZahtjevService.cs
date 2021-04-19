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

        public async Task<IEnumerable<ZahtjevDto>> GetAllZahtjeve()
        {
            return await _context.Zahtjevi
                .ProjectTo<ZahtjevDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ZahtjevDto>> GetZahtjeveByLoggedUser()
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

        public async Task<ZahtjevDto> OdobriZahtjev(OdobravanjeZahtjevaDto odobravanjeZahtjeva)
        {
            // trazimo zahtjev po id-u
            var zahtjev = await _context.Zahtjevi
                .Where(z => z.ZahtjevId == odobravanjeZahtjeva.ZahtjevId)
                .FirstOrDefaultAsync();

            //trazimo valutu koja se prodaje, tj. dobijemo njen id
            var valuta = zahtjev.ProdajemValutaId;

            // dobijemo period u kojem se ta valuta moze prodati po idu
            var vrijemeProdaje = await _context.Valute
                .Where(v => v.ValutaId == valuta)
                .Select(v => new VrijemeValuteDto()
                {
                    AktivnoOd = v.AktivnoOd,
                    AktivnoDo = v.AktivnoDo
                }
                ).FirstOrDefaultAsync();

            //trazimo sva vremena i gledamo da li je moguca prodaja
            TimeSpan start = vrijemeProdaje.AktivnoOd; //10 o'clock
            TimeSpan end = vrijemeProdaje.AktivnoDo; //12 o'clock
            TimeSpan now = DateTime.Now.TimeOfDay;

            if ((now < start) && (now > end))
            {
                throw new Exception("Zahtjev se ne može odobriti jer se navedena valuta ne može prodati u ovo doba dana.");
            }

            var odobravanje = new OdobravanjeZahtjevaDto()
            {
                ZahtjevId = odobravanjeZahtjeva.ZahtjevId,
                Prihvacen = odobravanjeZahtjeva.Prihvacen
            };


            // ove dvije linije ispod samo da vidim radi li ovo do sad, maknuti onda i nastaviti od onog ispod
            var odobreno =_mapper.Map<ZahtjevDto>(odobravanje);

            return odobreno;

            // NASTAVI TU DALJE
            // TREBA AZURIRATI IZNOSE, ZNACI PROCI KROZ SVA SREDSTVA, VJEROJATNO JAVNI API I NEKKAO PRETVORITI
            //if(odobravanjeZahtjeva.Prihvacen == 1)
            //{
            //    var sredstvo1 = new Sredstva()
            //    {
            //        S
            //    }
            //}





        }



    }
}
