using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
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

        public ValuteController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        // S ovime dobijemo sve tečajeve u odnosu na kunu
        [HttpGet("konverziju")]
        public async Task<Tecaj> GetValute()
        {
            return await _conversionService.GetAllAsync();
                

            

        }

    }
}
