﻿using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Domain.Services
{
    public interface IValuteService
    {
        Task<List<ValutaDto>> GetValute();
        Task<ValutaDetailsDto> GetValuta(int id);
        Task<ValutaDto> AddValuta(PostValutaDto postValutaDto);
        Task<ValutaDto> PutTecajValute([FromRoute] int id /*PutTecajValuteDto putValuta*/);
        Task<ValutaDto> PutValutaById(int id,PutValutaDto putValuta);
        void GetValuteToXml();
        void GetValuteFromXml();
    }
}
