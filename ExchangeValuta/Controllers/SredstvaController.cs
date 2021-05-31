using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExchangeValuta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SredstvaController : ControllerBase
    {
        private readonly ISredstvaService _service;

        public SredstvaController(ISredstvaService service)
        {
            _service = service;
        }

        [Authorize(Policy = "RequireSignedUpUser")]
        [HttpGet("SredstvaByLoggedUser")]
        public async Task<IEnumerable<SredstvaDto>> GetSredstvaByUser()
        {
            return await _service.GetSredstvaForLoggedUser();
        }

        [Authorize(Policy = "RequireSignedUpUser")]
        [HttpGet("ProtuvrijednostHRK")]
        public async Task<IEnumerable<ProtuvrijednostDto>> GetProtuvrijednost()
        {
            return await _service.GetProtuvrijednost();
        }


        [Authorize(Policy = "RequireSignedUpUser")]
        [HttpPost("PostSredstvaByLoggedUser")]
        public async Task<ActionResult<SredstvaDto>> PostSredstva([FromBody] PostSredstvaDto postSredstva)
        {
            var sredstva = await _service.PostSredstva(postSredstva);

            return Ok(sredstva);
        }

        [Authorize(Policy = "RequireSignedUpUser")]
        [HttpPut("PutSredstvaByLoggedUser")]
        public async Task<ActionResult<SredstvaDto>> PutSredstva([FromBody] PostSredstvaDto postSredstva)
        {
            var sredstvo = await _service.PutSredstva(postSredstva);

            return Ok(sredstvo);
        }


    }
}
