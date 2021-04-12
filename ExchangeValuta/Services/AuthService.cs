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
    public class AuthService : IAuthService
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        public AuthService()
        {
        }

       
    }
}
