using ExchangeValuta.Resources;
using ExchangeValuta.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IZahtjevService 
    {
        Task<ZahtjevDto> PostZahtjev(PostZahtjevDto postZahtjev);
        Task<IEnumerable<ZahtjevDto>> GetAllZahtjeve();

        Task<IEnumerable<ZahtjevDto>> GetZahtjeveByLoggedUser();
        Task<ZahtjevDto> OdobriZahtjev(OdobravanjeZahtjevaDto odobravanjeZahtjeva);

    }
}
