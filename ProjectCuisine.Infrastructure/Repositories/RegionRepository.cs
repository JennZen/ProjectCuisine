using Microsoft.EntityFrameworkCore;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Domain.Entities;
using ProjectCuisine.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Infrastructure.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ProjectCuisineDbContext _context;

        public RegionRepository(ProjectCuisineDbContext context)
        {
            _context = context;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.Include(r => r.Countries).AsNoTracking().ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regions.Include(r => r.Countries).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Regions.CountAsync();
        }
    }
}
