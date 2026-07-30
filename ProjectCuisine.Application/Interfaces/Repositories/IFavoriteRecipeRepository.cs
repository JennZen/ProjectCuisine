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
        public bool IsFavorite(string userId, int recipeId);

        public void Add(string userId, int recipeId);

        public void Remove(string userId, int recipeId);

        public List<Recipe> GetFavorites(string userId);
    }
}
