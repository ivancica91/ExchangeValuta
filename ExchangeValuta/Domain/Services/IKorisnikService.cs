using ExchangeValuta.Domain.Models;
using ExchangeValuta.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IKorisnikService
    {
        Task<ResponseDto> RegisterUserAsync(UserRegisterDto registerDto);
        Task<ResponseDto> ConfirmEmailAsync(ConfirmEmailDto confirmEmail);
        Task UpdateUser(UpdateUserDto updateUser);
        void Update(Korisnik korisnik);
    }
}
