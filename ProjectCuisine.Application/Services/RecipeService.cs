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

        private readonly ICountryService _countryService;

        private readonly ICategoryService _categoryService;

        private readonly RecipeMapper _mapper;

        public RecipeService(IRecipeRepository repository, ICountryService countryService, ICategoryService categoryService, RecipeMapper mapper)
        {
            _repository = repository;
            _countryService = countryService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(RecipeCreateDto recipeDto)
        {
            var foundRecipe = await _repository.GetByNameAsync(recipeDto.Name);

            var countryExists = await _countryService.GetByIdAsync(recipeDto.CountryId);

            var categoryExists = await _categoryService.GetByIdAsync(recipeDto.CategoryId);

            if (foundRecipe == null && countryExists != null && categoryExists != null)
            {
                var recipeEntity = _mapper.ToEntity(recipeDto);
                await _repository.AddAsync(recipeEntity);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(RecipeUpdateDto recipeDto)
        {
            var foundRecipe = await _repository.GetByIdAsync(recipeDto.Id);

            var countryExists = await _countryService.GetByIdAsync(recipeDto.CountryId);

            var categoryExists = await _categoryService.GetByIdAsync(recipeDto.CategoryId);

            if (foundRecipe != null && countryExists != null && categoryExists != null)
            {
                _mapper.UpdateEntity(recipeDto, foundRecipe);
                await _repository.UpdateAsync(foundRecipe);
                return true;
            }

            return false;
        }

        public async Task<List<RecipeListDto>> GetAllAsync()
        {
            var recipes = await _repository.GetAllAsync();
            return _mapper.ToListDtos(recipes);
        }

        public async Task<List<RecipeDetailsDto>> GetAllDetailedAsync()
        {
            var recipes = await _repository.GetAllAsync();
            return _mapper.ToDetailsDtos(recipes);
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

        public async Task<RecipeUpdateDto?> GetForUpdateByIdAsync(int id)
        {
            var recipe = await _repository.GetByIdAsync(id);
            if (recipe == null)
            {
                return null;
            }
            return _mapper.ToUpdateDto(recipe);
        }

        public async Task<int> GetCountAsync()
        {
            return await _repository.GetCountAsync();
        }

        public async Task<List<RecipeListDto>> GetByCategoryAndCountryAsync(int categoryId, int countryId)
        {
            var recipes = await _repository.GetByCategoryAndCountryAsync(categoryId, countryId);
            return _mapper.ToListDtos(recipes);
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
