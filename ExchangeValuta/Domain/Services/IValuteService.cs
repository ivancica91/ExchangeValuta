using ExchangeValuta.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IValuteService
    {
        Task<List<ValutaDto>> GetValute();
        Task<ValutaDto> GetValuta(int id);
        Task<ValutaDto> AddValuta(PostValutaDto postValutaDto);
        Task<ValutaDto> PutTecajValute(PutTecajValuteDto putValuta);
        Task<ValutaDto> PutValutaByName(PutValutaDto putValuta);
        void GetValuteToXml();
        void GetValuteFromXml();
    }
}
