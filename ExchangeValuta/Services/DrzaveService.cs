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

        public async Task<DrzavaDetaljiDto> GetDrzavaByValutaId(int valutaId)
        {
            return await _context.Drzave
               .Include(v => v.Valuta)
               .Where(x => x.ValutaId == valutaId)
               .ProjectTo<DrzavaDetaljiDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<DrzavaDetaljiDto>> GetAllDrzave()
        {
            return await _context.Drzave
                .ProjectTo<DrzavaDetaljiDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<HimnaDto> GetHimnaDrzave(int valutaId)
        {
            return await _context.Drzave
                .Include(v => v.Valuta)
                .Where(d => d.ValutaId == valutaId)
                .ProjectTo<HimnaDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

    }
}
