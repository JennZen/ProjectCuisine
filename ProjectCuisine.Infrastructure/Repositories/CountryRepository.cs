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
    public class CountryRepository: ICountryRepository
    {
        private readonly ProjectCuisineDbContext _context;

        public CountryRepository(ProjectCuisineDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _context.Countries.AsNoTracking().ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            return await _context.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Country>> GetAllByRegionAsync(int regionId)
        {
            return await _context.Countries.AsNoTracking().Where(c => c.RegionId == regionId).ToListAsync();
        }
    }
}
