using ExchangeValuta.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IAuthService
    {
        Task<ResponseDto> RegisterUserAsync(UserRegisterDto registerDto);
        Task<ResponseDto> ConfirmEmailAsync(ConfirmEmailDto confirmEmail);
    }
}
