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

        public List<RecipeListDto> GetFavorites(string userId)
        {
            var favoriteRecipes = _repository.GetFavorites(userId);
            return _mapper.ToListDtos(favoriteRecipes);
        }

        public void Toggle(string userId, int recipeId)
        {
            if (_repository.IsFavorite(userId, recipeId))
            {
                _repository.Remove(userId, recipeId);
            }
            else
            {
                _repository.Add(userId, recipeId);
            }
        }
    }
}
