using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Services
{
    public interface IFavoriteRecipeService
    {
        public List<RecipeListDto> GetFavorites(string userId);

        public void Toggle(string userId, int recipeId);
    }
}
