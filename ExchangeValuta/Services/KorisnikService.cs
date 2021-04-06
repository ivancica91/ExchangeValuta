using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExchangeValuta.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        public KorisnikService(UserManager<Korisnik> userManager, IConfiguration configuration, IMailService mailService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mailService = mailService;
        }

        public async Task<ResponseDto> RegisterUserAsync(UserRegisterDto registerDto)
        {
            if (registerDto == null)
                throw new NullReferenceException("Nisu ispunjeni svi podaci");

            if (registerDto.Lozinka != registerDto.PotvrdiLozinku)
                return new ResponseDto
                {
                    Message = "Lozinke se ne podudaraju",
                    IsSuccess = false
                };


            var user = new Korisnik
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                Ime = registerDto.Ime,
                Prezime = registerDto.Prezime,
                Lozinka = registerDto.Lozinka
            };

            // kreiranje korisnika
            var result = await _userManager.CreateAsync(user, registerDto.Lozinka);

            if (result.Succeeded)
            {
                var userFromDb = await _userManager.FindByNameAsync(user.UserName);
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(userFromDb);

                var uriBuilder = new UriBuilder(_configuration["ReturnPaths:ConfirmEmail"]); /*http://localhost:4200/confirmemail */
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["token"] = token;
                query["userid"] = userFromDb.Id.ToString();
                uriBuilder.Query = query.ToString();
                var urlString = uriBuilder.ToString();

                var senderEmail = _configuration["ReturnPaths:SenderEmail"];
                await _mailService.SendEmailAsync(senderEmail, userFromDb.Email, "Potvrda email adrese", "Potvrdi email klikom na:" + urlString);

                var roleResult = await _userManager.AddToRoleAsync(user, "korisnik");

                if (!roleResult.Succeeded) return new ResponseDto { Message = "Neuspjelo dodavanje uloge", Errors = result.Errors.Select(e => e.Description) };


                return new ResponseDto
                {
                    Message = "Uspješna registracija, potvrdite svoj email putem linka poslanog na email adresu navedenu prilikom registracije.",
                    IsSuccess = true
                };
            }

            return new ResponseDto
            {
                Message = "Neuspješna registracija korisnika",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        public async Task<ResponseDto> ConfirmEmailAsync(ConfirmEmailDto confirmEmail)
        {
            var user = await _userManager.FindByIdAsync(confirmEmail.UserId);
            if (user == null)
                return new ResponseDto
                {
                    Message = "Korisnik ne postoji",
                    IsSuccess = false
                };

            var result = await _userManager.ConfirmEmailAsync(user, Uri.UnescapeDataString(confirmEmail.Token));

            if (result.Succeeded)
                return new ResponseDto
                {
                    Message = "Email je uspješno potvrđen.",
                    IsSuccess = true
                };

            return new ResponseDto
            {
                Message = "Potvrda Emaila nije uspjela.",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}
