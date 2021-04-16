using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Services
{
    public class ValuteService : IValuteService
    {
        private readonly ExchangeDbContext _context;
        private readonly IMapper _mapper;

        public ValuteService(ExchangeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ValutaDto>> GetValute()
        {
            return await _context.Valute
                .ProjectTo<ValutaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ValutaDto> GetValuta(int id)
        {
            return await _context.Valute
                .Where(v => v.ValutaId == id)
                .ProjectTo<ValutaDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }


    }
}
