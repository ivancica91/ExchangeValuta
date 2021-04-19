using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExchangeValuta.Services
{
    public class ValuteService : IValuteService
    {
        private readonly ExchangeDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _client;

        public ValuteService(ExchangeDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor/*, HttpClient client*/)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            //_client = client;
        }

        public async Task<IEnumerable<ValutaDto>> GetValute()
        {
            return await _context.Valute
                .ProjectTo<ValutaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ValutaDto> GetValuta(int id)
        {
            return await _context.Valute
                .Where(v => v.ValutaId == id)
                .ProjectTo<ValutaDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        //public async Task<ValutaDto> PutTecajValute(PutValutaDto putValuta)
        //{
        //    var url = $"https://v6.exchangerate-api.com/v6/09a14a921f6de3a3c311a083/pair/HRK/{putValuta.Naziv}";
        //    var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var id = _context.Korisnici.Where(k => k.UserName == userName)
        //        .FirstOrDefault().Id;

        //    var valuta = _context.Valute
        //        .Where(v => v.ValutaId == putValuta.ValutaId && v.KorisnikId == id)
        //        .FirstOrDefaultAsync();

        //    if(valuta == null)
        //    {
        //        throw new Exception("Tražena valuta ne postoji ili nemate pristup traženoj valuti.");
        //    }

        //    var zadnjeAzuriranje = putValuta.DatumAzuriranja.Date;

        //    if(zadnjeAzuriranje == DateTime.Now.Date)
        //    {
        //        throw new Exception("Tečaj valute je već ažuriran na današnji dan, molimo pokušajte sutra.");
        //    }

        //    var tecaj = await _client.GetAsync(url);

        //    var content = await tecaj.Content.ReadAsStringAsync();
        //    double tec;

        //    var result = double.TryParse(content, out tec); ;


        //    //    var httpResponse = await _client.GetAsync(_baseUrl);

        //    //if (!httpResponse.IsSuccessStatusCode)
        //    //{
        //    //    throw new Exception("Nije moguće dohvatiti valute");
        //    //}

        //    //var content = await httpResponse.Content.ReadAsStringAsync();
        //    //var tasks = JsonConvert.DeserializeObject<Tecaj>(content);

        //    //return tasks;


        //    var mod = new Valuta()
        //    {
        //        ValutaId = putValuta.ValutaId,
        //        Naziv = putValuta.Naziv,
        //        DatumAzuriranja = DateTime.Now,
        //        Tecaj = tec
        //    };

        //    await _context.SaveChangesAsync();

        //    return _mapper.Map<ValutaDto>(mod);

        //}


    }
}
