using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeValuta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuteController : ControllerBase
    {
        //private readonly IConversionService _conversionService;
        private readonly IValuteService _service;
        private  HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public ValuteController(/*IConversionService conversionService,*/ IValuteService service, HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            //_conversionService = conversionService;
            _service = service;
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }

        // S ovime dobijemo sve tečajeve u odnosu na kunu
        // bzvz, treba vidjeti u funkc. sto je ostalo
        //[HttpGet("konverziju")]
        //public async Task<Tecaj> GetProtuvrijednostOdHRK()
        //{
        //    return await _conversionService.GetAllAsync();
        //}

        [HttpGet("PopisValuta")]
        public async Task<IEnumerable<ValutaDto>> GetValute()
        {
            var valute = await _service.GetValute();
            return valute;
        }

        [HttpGet("{id}")]
        public async Task<ValutaDto> GetValutaById(int id)
        {
            return await _service.GetValuta(id);
        }

        [Authorize(Policy = "RequireModeratorRole")]
        [HttpPut("AzurirajTecaj")]
        public async Task<ValutaDto> PutTecajValute(PutValutaDto putValuta)
        {
            return await _service.PutTecajValute(putValuta);
        }

        //[HttpGet]
        //public async Task<string> Get(string naziv)
        //{
        //    var url = $"https://v6.exchangerate-api.com/v6/09a14a921f6de3a3c311a083/pair/HRK/{naziv}";
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync(url);
        //    return await response.Content.ReadAsStringAsync();
        //}




    }
}
