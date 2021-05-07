using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ExchangeValuta.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly ExchangeDbContext _context;
        private readonly UserManager<Korisnik> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public KorisnikService(ExchangeDbContext context,UserManager<Korisnik> userManager, IConfiguration configuration,
            IMailService mailService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
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

            var postojeciKorisnik = await _context.Korisnici
                .Where(u => u.Email == registerDto.Email)
                .FirstOrDefaultAsync();

            if(postojeciKorisnik != null)
            {
                throw new Exception("Korisnik s navedenim emailom već postoji.");
            }


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


        public async Task<IEnumerable<GetUsersDto>> GetAllUsers()
        {
            return await _context.Korisnici
            .ProjectTo<GetUsersDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<KorisnikDto> PostUser(PostUserDto postUser)
        {
            var user = new Korisnik()
            {
                UserName = postUser.UserName,
                Ime = postUser.Ime,
                Prezime = postUser.Prezime,
                Email = postUser.Email,
                Slika = postUser.Slika,
                EmailConfirmed = true,
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Lozinka = postUser.Lozinka
            };

            await _userManager.CreateAsync(user, user.Lozinka);
            await _userManager.AddToRoleAsync(user, "korisnik");

            await _context.SaveChangesAsync();

            var korisnik = _mapper.Map<KorisnikDto>(user);
            return korisnik;
        }


        public async Task UpdateUser(UpdateUserDto updateUser)
        {
            var user = await _userManager.Users
                .Where(k => k.Id == updateUser.Id)
                .FirstOrDefaultAsync();

            _mapper.Map(updateUser, user);
            Update(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateLoggedUser(UpdateLoggedUserDto updateUser)
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.Users
                .Where(k => k.UserName == userName)
                .FirstOrDefaultAsync();

            _mapper.Map(updateUser, user);
            Update(user);
           await _context.SaveChangesAsync();
        }

        public async Task EditRoles(string userName, string role)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new Exception("Korisnik nije pronađen");
            }

            var selectedRoles = role.Split(",").ToArray();

            var userRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded)
            {
                throw new Exception("Pogreška pri dodavanju uloge.");
            }

            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

             await _userManager.GetRolesAsync(user);

        }


        public void Update(Korisnik korisnik)
        {
            var entry = _context.Entry(korisnik).State = EntityState.Modified;
        }
    }
}
