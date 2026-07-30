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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProjectCuisineDbContext _context;

        public CategoryRepository(ProjectCuisineDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.AsNoTracking().ToList();
        }
    }
}
