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

        public List<Region> GetAll()
        {
            return _context.Regions.Include(r => r.Countries).AsNoTracking().ToList();
        }

        public Region GetById(int id)
        {
            return _context.Regions.Include(r => r.Countries).FirstOrDefault(r => r.Id == id);
        }
    }
}
