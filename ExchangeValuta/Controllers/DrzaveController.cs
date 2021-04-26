using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public DrzaveController(ExchangeDbContext context, IHttpClientFactory httpClientFactory, IDrzaveService service)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _service = service;
        }

        [HttpGet("HimnaByDrzavaId")]
        public async Task<HimnaDto> GetHimnaByDrzavaId(int drzavaId)
        {
            return await _service.GetHimnaDrzave(drzavaId);
        }


        [HttpGet("DrzavaByValuta")]
        public async Task<MapDrzavaDto> GetDrzavaByLongAndLat(int drzavaId)
        {
            // kul, radi, samo prebaci u servis sve!
            var drzava = await _context.Drzave.FindAsync(drzavaId);


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
