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

        public bool IsFavorite(string userId, int recipeId)
        {
            return _context.FavoriteRecipes.Any(f => f.UserId == userId && f.RecipeId == recipeId);
        }

        public void Add(string userId, int recipeId)
        {
            if (IsFavorite(userId, recipeId)) return;

            _context.FavoriteRecipes.Add(new FavoriteRecipe { UserId = userId, RecipeId = recipeId });
            _context.SaveChanges();
        }

        public void Remove(string userId, int recipeId)
        {
            var favoriteRecipe = _context.FavoriteRecipes.FirstOrDefault(f => f.UserId == userId && f.RecipeId == recipeId);

            if (favoriteRecipe != null)
            {
                _context.FavoriteRecipes.Remove(favoriteRecipe);
                _context.SaveChanges();
            }
        }

        public List<Recipe> GetFavorites(string userId)
        {
            return _context.FavoriteRecipes.Where(f => f.UserId == userId)
                           .Include(f => f.Recipe).ThenInclude(r => r.Category)
                           .Include(f => f.Recipe).ThenInclude(r => r.Country)
                           .Select(f => f.Recipe)
                           .AsNoTracking()
                           .ToList();
        }
    }
}
