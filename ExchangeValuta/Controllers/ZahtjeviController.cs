using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZahtjeviController : ControllerBase
    {
        private readonly IZahtjevService _service;

        public ZahtjeviController(IZahtjevService service)
        {
            _service = service;
        }

        [HttpPost("Zahtjev")]
        public async Task<ZahtjevDto> PostZahtjev(PostZahtjevDto postZahtjev)
        {
            return await _service.PostZahtjev(postZahtjev);
        }

        [HttpGet("ZahtjeveByLoggedUser")]
        public async Task<IEnumerable<ZahtjevDto>> GetZahtjeve()
        {
            return await _service.GetZahtjeve();
        }
    }
}
