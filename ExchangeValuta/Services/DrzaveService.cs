using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExchangeValuta.Domain.Models;
using ExchangeValuta.Domain.Services;
using ExchangeValuta.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeValuta.Services
{
    public class DrzaveService : IDrzaveService
    {
        private readonly ExchangeDbContext _context;
        private readonly IMapper _mapper;

        public DrzaveService(ExchangeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HimnaDto> GetHimnaDrzave(int drzavaId)
        {
            return await _context.Drzave
                .Where(d => d.DrzavaId == drzavaId)
                .ProjectTo<HimnaDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

        }

    }
}
