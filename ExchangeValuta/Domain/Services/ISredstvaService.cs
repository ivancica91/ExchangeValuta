using ExchangeValuta.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface ISredstvaService
    {
        Task<IEnumerable<SredstvaDto>> GetSredstvaForLoggedUser();
        Task<SredstvaDto> PostSredstva(PostSredstvaDto postSredstva);
        Task<SredstvaDto> PutSredstva(PostSredstvaDto postSredstva);

    }
}
