using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Services
{
    public class FavoriteRecipeService : IFavoriteRecipeService
    {
        private readonly IFavoriteRecipeRepository _repository;

        private readonly RecipeMapper _mapper;

        public FavoriteRecipeService(IFavoriteRecipeRepository repository, RecipeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RecipeListDto>> GetFavorites(string userId)
        {
            var favoriteRecipes = await _repository.GetFavoritesAsync(userId);
            return _mapper.ToListDtos(favoriteRecipes);
        }

        public async Task Toggle(string userId, int recipeId)
        {
            if (await _repository.IsFavoriteAsync(userId, recipeId))
            {
                await _repository.RemoveAsync(userId, recipeId);
            }
            else
            {
                await _repository.AddAsync(userId, recipeId);
            }
        }
    }
}
