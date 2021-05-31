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

        public ValuteController(IValuteService service)
        {
            _service = service;
        }

        [HttpGet("PopisValuta")]  
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

        [Authorize(Policy = "RequireAdminRole")]  
        [HttpPost("DodajValutu")]
        public async Task<EditValutaDto> AddValuta(PostValutaDto postValutaDto)
        {
            return await _service.AddValuta(postValutaDto);
        }

        [Authorize(Policy = "RequireModeratorRole")]
        [HttpPut("AzurirajTecaj/{id}")]
        public async Task<ValutaDto> PutTecajValute([FromRoute] int id)
        {
            return await _service.PutTecajValute(id);
        }

        [Authorize(Policy = "RequireAdminRole")]   
        [HttpPut("AzurirajValutu/{id}")]
        public async Task<EditValutaDto> PutValutaById(int id,PutValutaDto putValuta)
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








    }
}
