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
        Task<IEnumerable<GetUsersDto>> GetAllUsers();
        Task<KorisnikDto> GetUserByName(string userName);
        Task<KorisnikDto> GetUserById(int id);

        Task<KorisnikDto> PostUser(PostUserDto postUser);
        Task UpdateLoggedUser(UpdateLoggedUserDto updateUser);
        Task UpdateUser(UpdateUserDto updateUser, int id);
        Task EditRoles(string userName, string role);

        void Update(Korisnik korisnik);
    }
}
