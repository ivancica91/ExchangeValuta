using AutoMapper;
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
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeValuta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuteController : ControllerBase
    {
        private readonly IValuteService _service;
        private readonly IHttpClientFactory _httpClientFactory;

        public ValuteController(IValuteService service, IHttpClientFactory httpClientFactory)
        {
            _service = service;
            _httpClientFactory = httpClientFactory;
        }

        // S ovime dobijemo sve tečajeve u odnosu na kunu
        // bzvz, treba vidjeti u funkc. sto je ostalo
        //[HttpGet("konverziju")]
        //public async Task<Tecaj> GetProtuvrijednostOdHRK()
        //{
        //    return await _conversionService.GetAllAsync();
        //}

        [HttpGet("PopisValuta")]  // to namne treba, samo za test bilo
        public async Task<List<ValutaDto>> GetValute()
        {
            var valute = await _service.GetValute();
            return valute;
        }

        [HttpGet("{id}")]
        public async Task<ValutaDetailsDto> GetValutaById(int id)
        {
            return await _service.GetValuta(id);
        }

        [Authorize(Policy = "RequireAdminRole")]   // testiraj ovo!
        [HttpPost("DodajValutu")]
        public async Task<ValutaDto> AddValuta(PostValutaDto postValutaDto)
        {
            return await _service.AddValuta(postValutaDto);
        }

        [Authorize(Policy = "RequireModeratorRole")]
        [HttpPut("AzurirajTecaj/{id}")]
        public async Task<ValutaDto> PutTecajValute([FromRoute] int id/*PutTecajValuteDto putValuta*/)
        {
            return await _service.PutTecajValute(id);
        }

        [Authorize(Policy = "RequireAdminRole")]   // testiraj ovo!
        [HttpPut("AzurirajValutu/{id}")]
        public async Task<ValutaDto> PutValutaById(int id,PutValutaDto putValuta)
        {
            return await _service.PutValutaById(id,putValuta);
        }

        [HttpGet("ValuteToXml")]
        public void GetValuteToXml()
        {
             _service.GetValuteToXml();
        }

        [HttpPut("ValuteFromxml")]
        public void PutValuteFromXml()
        {
            _service.GetValuteFromXml();
        }


        // TODO
        // VALUTEFROMXML






    }
}
