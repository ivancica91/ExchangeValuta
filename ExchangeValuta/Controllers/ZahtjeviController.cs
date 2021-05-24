using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy ="RequireModeratorRole")]
        [HttpGet("AllZahtjeve")]
        public async Task<IEnumerable<ZahtjevDto>> GetAllZahtjeve()
        {
            return await _service.GetAllZahtjeve();
        }


        [HttpGet("AllOdobreneZahtjeve")]
        public async Task<IEnumerable<UkupnoProdaneValuteDto>> GetAllOdobreneZahtjeve([FromQuery] DateTime? from = null, DateTime? to = null, int? id = null)
        {
            return await _service.GetAllOdobreneZahtjeve(from, to, id);
        }




        [Authorize(Policy = "RequireSignedUpUser")]
        [HttpPost("Zahtjev")]
        public async Task<ZahtjevDto> PostZahtjev(PostZahtjevDto postZahtjev)
        {
            return await _service.PostZahtjev(postZahtjev);
        }

        [Authorize(Policy = "RequireSignedUpUser")]
        [HttpGet("ZahtjeveByLoggedUser")]
        public async Task<IEnumerable<ZahtjevDto>> GetZahtjeve()
        {
            return await _service.GetZahtjeveByLoggedUser();
        }

        [HttpGet("ZahtjeveByUser")]
        public async Task<IEnumerable<ZahtjevDto>> GetZahtjeveByUser()
        {
            return await _service.GetZahtjeveByUser();
        }


        [HttpPut("OdobravanjeZahtjeva")]
        public async Task<ZahtjevDto> OdobriZahtjev(OdobravanjeZahtjevaDto odobravanjeZahtjeva)
        {
            return await _service.OdobriZahtjev(odobravanjeZahtjeva);
        }

    }
}
