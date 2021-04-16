using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
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
        private readonly IConversionService _conversionService;
        private readonly IValuteService _service;

        public ValuteController(IConversionService conversionService, IValuteService service)
        {
            _conversionService = conversionService;
            _service = service;
        }

        // S ovime dobijemo sve tečajeve u odnosu na kunu
        [HttpGet("konverziju")]
        public async Task<Tecaj> GetProtuvrijednostOdHRK()
        {
            return await _conversionService.GetAllAsync();
        }

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



    }
}
