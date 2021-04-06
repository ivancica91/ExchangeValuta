using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public AuthController(IKorisnikService korisnikService)
        {
            _korisnikService = korisnikService;
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
    }
}
