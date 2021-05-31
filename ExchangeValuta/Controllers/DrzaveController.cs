using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExchangeValuta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrzaveController : ControllerBase
    {
        private readonly IDrzaveService _service;

        public DrzaveController(IDrzaveService service)
        {
            _service = service;
        }

        [HttpGet("DrzavaByValutaId/{id}")]
        public async Task<DrzavaDetaljiDto> GetDrzavaByValutaId(int id)
        {
            return await _service.GetDrzavaByValutaId(id);
        }

        [HttpGet("PopisDrzava")]
        public async Task<IEnumerable<DrzavaDetaljiDto>> GetAllDrzave()
        {
            return await _service.GetAllDrzave();
        }

        [HttpGet("HimnaByDrzavaId/{id}")]
        public async Task<HimnaDto> GetHimnaByDrzavaId(int id)
        {
            return await _service.GetHimnaDrzave(id);
        }

    }
}
