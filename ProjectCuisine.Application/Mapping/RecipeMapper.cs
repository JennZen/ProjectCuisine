using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Domain.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Mapping
{
    [Mapper]
    public partial class RecipeMapper
    {
        public partial RecipeCreateDto ToCreateDto(Recipe recipe);

        public partial RecipeUpdateDto ToUpdateDto(Recipe recipe);

        [MapProperty($"{nameof(Recipe.Category)}.{nameof(Category.Name)}", nameof(RecipeDetailsDto.CategoryName))]
        [MapProperty($"{nameof(Recipe.Country)}.{nameof(Country.Name)}", nameof(RecipeDetailsDto.CountryName))]
        public partial RecipeDetailsDto ToDetailsDto(Recipe recipe);

        public partial List<RecipeDetailsDto> ToDetailsDtos(List<Recipe> recipes);

        [MapProperty($"{nameof(Recipe.Category)}.{nameof(Category.Name)}", nameof(RecipeListDto.CategoryName))]
        [MapProperty($"{nameof(Recipe.Country)}.{nameof(Country.Name)}", nameof(RecipeListDto.CountryName))]
        public partial RecipeListDto ToListDto(Recipe recipe);

        public partial List<RecipeListDto> ToListDtos(List<Recipe> recipeCreateDto);

        public partial Recipe ToEntity(RecipeCreateDto recipeCreateDto);

        public partial Recipe ToEntity(RecipeUpdateDto recipeUpdateDto);

        public partial void UpdateEntity(RecipeUpdateDto dto, Recipe entity);
    }
}
