﻿using ExchangeValuta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(Korisnik user);
    }
}
