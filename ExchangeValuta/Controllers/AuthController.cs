using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;

        public AuthController(IKorisnikService korisnikService, ITokenService tokenService, UserManager<Korisnik> userManager, SignInManager<Korisnik> signInManager)
        {
            _korisnikService = korisnikService;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _korisnikService.RegisterUserAsync(registerDto);

                if (result.IsSuccess)
                    return Ok(result); // Status code 200

                return BadRequest(result);
            }
            return BadRequest("Provjerite ponovno upisane podatke."); // Status code 400
        }


        [HttpPost("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailDto confirmEmail)
        {
            var result = await _korisnikService.ConfirmEmailAsync(confirmEmail);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<KorisnikDto>> Login(UserLoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null)
            {
                return Unauthorized("Korisnik nije pronađen");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Lozinka, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return new KorisnikDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = await _tokenService.CreateToken(user),
                    Email = user.Email,
                    Ime = user.Ime,
                    Prezime = user.Prezime,
                    Slika = user.Slika
                };
            }
            if (result.IsLockedOut)
            {
                return Unauthorized("Vaš račun je blokiran. Moći ćete opet ući nakon reseta administratora.");
            }
            else
            {
                return Unauthorized("Pogrešna lozinka");
            }
        }

        [Authorize(Policy = "RequireSignedUpUser")]
        [HttpPut("AzurirajProfil")]
        public async Task PutUser(UpdateLoggedUserDto updateUser)
        {
            await _korisnikService.UpdateLoggedUser(updateUser);
        }

        // TODO
        // UNLOCK USERA
    }
}
