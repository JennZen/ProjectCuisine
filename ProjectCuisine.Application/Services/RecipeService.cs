using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Application.Mapping;
using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;

        private readonly RecipeMapper _mapper;

        public RecipeService(IRecipeRepository repository, RecipeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(RecipeCreateDto recipeDto)
        {
            var foundRecipe = await _repository.GetByNameAsync(recipeDto.Name);

            if(foundRecipe == null)
            {
                var recipeEntity = _mapper.ToEntity(recipeDto);
                await _repository.AddAsync(recipeEntity);
            }
        }

        public async Task UpdateAsync(RecipeUpdateDto recipeDto)
        {
            var foundRecipe = await _repository.GetByIdAsync(recipeDto.Id);

            if (foundRecipe != null)
            {
                _mapper.UpdateEntity(recipeDto, foundRecipe);
                await _repository.UpdateAsync(foundRecipe);
            }
        }

        public async Task<List<RecipeListDto>> GetAllAsync()
        {
            var recipes = await _repository.GetAllAsync();
            return _mapper.ToListDtos(recipes);
        }

        public async Task<List<RecipeListDto>> GetByCountryIdAsync(int countryId)
        {
            var recipes = await _repository.GetByCountryIdAsync(countryId);
            return _mapper.ToListDtos(recipes);
        }

        public async Task<RecipeDetailsDto?> GetByIdAsync(int id)
        {
            var recipe = await _repository.GetByIdAsync(id);
            if (recipe == null)
            {
                return null;
            }
            return _mapper.ToDetailsDto(recipe);
        }

        public async Task DeleteAsync(int id)
        {
            var recipe = await _repository.GetByIdAsync(id);
            if (recipe != null)
            {
                await _repository.DeleteAsync(recipe);
            }
        }

    }
}
