using ExchangeValuta.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IValuteService
    {
        Task<IEnumerable<ValutaDto>> GetValute();
        Task<ValutaDto> GetValuta(int id);
    }
}
