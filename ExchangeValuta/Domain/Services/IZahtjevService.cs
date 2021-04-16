using ExchangeValuta.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IZahtjevService
    {
        Task<ZahtjevDto> PostZahtjev(PostZahtjevDto postZahtjev);
        Task<IEnumerable<ZahtjevDto>> GetZahtjeve();

    }
}
