using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Domain.Entities;
using ProjectCuisine.Infrastructure.Data;

namespace ProjectCuisine.Infrastructure.Repositories
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly ProjectCuisineDbContext _context;

        public RecipeRepository(ProjectCuisineDbContext context) 
        { 
            _context = context;
        }

        public async Task AddAsync(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking().
                ToListAsync();
        }

        public async Task<List<Recipe>> GetByCountryIdAsync(int countryId)
        {
            return await _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking().
                Where(r => r.CountryId == countryId).
                ToListAsync();
        }


        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Recipe?> GetByNameAsync(string name)
        {
            return await _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking()
                .FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<List<Recipe>> GetByCategoryAndCountryAsync(int categoryId, int countryId)
        {
            return await _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking().
                Where(r => r.CategoryId == categoryId && r.CountryId == countryId).
                ToListAsync();
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
