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

        public Task<List<RecipeListDto>> GetByCountryIdAsync(int countryId);

        public Task<RecipeDetailsDto?> GetByIdAsync(int id);

        public Task<List<RecipeListDto>> GetByCategoryAndCountryAsync(int categoryId, int countryId);

        public Task UpdateAsync(RecipeUpdateDto recipeDto);

        public Task DeleteAsync(int id);

        public Task CreateAsync(RecipeCreateDto recipeCreateDto);
    }
}
