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
    public class FavoriteRecipeRepository : IFavoriteRecipeRepository
    {
        private readonly ProjectCuisineDbContext _context;

        public FavoriteRecipeRepository(ProjectCuisineDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsFavoriteAsync(string userId, int recipeId)
        {
            return await _context.FavoriteRecipes.AnyAsync(f => f.UserId == userId && f.RecipeId == recipeId);
        }

        public async Task AddAsync(string userId, int recipeId)
        {
            if (await IsFavoriteAsync(userId, recipeId)) return;

            await _context.FavoriteRecipes.AddAsync(new FavoriteRecipe { UserId = userId, RecipeId = recipeId });
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(string userId, int recipeId)
        {
            var favoriteRecipe = await _context.FavoriteRecipes.FirstOrDefaultAsync(f => f.UserId == userId && f.RecipeId == recipeId);

            if (favoriteRecipe != null)
            {
                _context.FavoriteRecipes.Remove(favoriteRecipe);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Recipe>> GetFavoritesAsync(string userId)
        {
            return await _context.FavoriteRecipes.Where(f => f.UserId == userId)
                           .Include(f => f.Recipe).ThenInclude(r => r.Category)
                           .Include(f => f.Recipe).ThenInclude(r => r.Country)
                           .Select(f => f.Recipe)
                           .AsNoTracking()
                           .ToListAsync();
        }
    }
}
