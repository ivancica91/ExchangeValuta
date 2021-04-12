using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeValuta.Services
{
    public class ConversionService :IConversionService
    {

        private const string _baseUrl = "https://v6.exchangerate-api.com/v6/09a14a921f6de3a3c311a083/latest/HRK";
        private readonly HttpClient _client;

        public ConversionService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Tecaj> GetAllAsync()
        {
            var httpResponse = await _client.GetAsync(_baseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Nije moguće dohvatiti valute");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<Tecaj>(content);

            return tasks;
        }
        //public async Task<Tecaj> GetTecajAsync(int id)
        //{

        //}
        //public async Task<Tecaj> CreateTecajAsync(Tecaj task)
        //{

        //}
        //public async Task<Tecaj> UpdateTecajAsync(Tecaj task)
        //{

        //}
        //public async Task DeleteTecajAsync(int id)
        //{

        //}


    }
}
