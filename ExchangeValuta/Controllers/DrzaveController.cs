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
        private readonly ExchangeDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDrzaveService _service;
        private readonly IMapper _mapper;

        public DrzaveController(ExchangeDbContext context, IHttpClientFactory httpClientFactory, IDrzaveService service)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
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


        [HttpGet("DrzavaByValuta/{id}")]
        public async Task<MapDrzavaDto> GetMapDrzavaByValutaId([FromRoute]int id)
        {
            // kul, radi, samo prebaci u servis sve!
            //var drzava = await _context.Drzave.FindAsync(drzavaId);
            var drzava = await _context.Drzave
                .Include(v => v.Valuta)
                .Where(x => x.ValutaId == id)
                .FirstOrDefaultAsync();
                


            var httpClient = _httpClientFactory.CreateClient();
            var url = $"https://nominatim.openstreetmap.org/reverse?lat={drzava.Sirina}&lon={drzava.Duljina}&zoom=3&format=json";
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(".NET Framework Test Client");
            var response = await httpClient.GetAsync(url);
            var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<OpenStreetMap>(responseStream);





            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.UserAgent = ".NET Framework Test Client";
            //var response = (HttpWebResponse)request.GetResponse();
            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var prikaz = new MapDrzavaDto()
            {
                Naziv = responseObject.display_name
            };

            return prikaz;


        }
    }
}
