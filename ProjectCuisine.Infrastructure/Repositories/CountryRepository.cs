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

        public List<Country> GetAll()
        {
            return _context.Countries.AsNoTracking().ToList();
        }

        public Country GetById(int id)
        {
            return _context.Countries.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Country>> GetAllByRegionAsync(int regionId)
        {
            return await _context.Countries.AsNoTracking().Where(c => c.RegionId == regionId).ToListAsync();
        }
    }
}
