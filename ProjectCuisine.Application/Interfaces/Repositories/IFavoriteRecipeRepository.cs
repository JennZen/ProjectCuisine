using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Repositories
{
    public interface IFavoriteRecipeRepository
    {
        public Task<bool> IsFavoriteAsync(string userId, int recipeId);

        public Task AddAsync(string userId, int recipeId);

        public Task RemoveAsync(string userId, int recipeId);
        public Task<List<Recipe>> GetFavoritesAsync(string userId);
    }
}
