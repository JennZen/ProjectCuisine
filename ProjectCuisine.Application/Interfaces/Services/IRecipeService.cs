using ProjectCuisine.Application.DTOs.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Services
{
    public interface IRecipeService
    {
        public Task<List<RecipeListDto>> GetAllAsync();

        public Task<List<RecipeDetailsDto>> GetAllDetailedAsync();

        public Task<List<RecipeListDto>> GetByCountryIdAsync(int countryId);

        public Task<RecipeDetailsDto?> GetByIdAsync(int id);

        public Task<RecipeUpdateDto?> GetForUpdateByIdAsync(int id);

        public Task<List<RecipeListDto>> GetByCategoryAndCountryAsync(int categoryId, int countryId);

        public Task<int> GetCountAsync();

        public Task<bool> UpdateAsync(RecipeUpdateDto recipeDto);

        public Task DeleteAsync(int id);

        public Task<bool> CreateAsync(RecipeCreateDto recipeCreateDto);
    }
}
