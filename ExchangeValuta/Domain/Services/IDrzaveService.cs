using ExchangeValuta.Resources;
using ExchangeValuta.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IDrzaveService 
    {
        Task<DrzavaDetaljiDto> GetDrzavaByValutaId(int valutaId);
        Task<IEnumerable<DrzavaDetaljiDto>> GetAllDrzave();
        Task<HimnaDto> GetHimnaDrzave(int valutaId);
    }
}
