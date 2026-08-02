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
        public List<RecipeListDto> GetAll();

        public List<RecipeListDto> GetByCountryId(int countryId);

        public RecipeDetailsDto? GetById(int id);

        public void Update(RecipeUpdateDto recipeDto);

        public void Delete(int id);

        public void Create(RecipeCreateDto recipeCreateDto);
    }
}
