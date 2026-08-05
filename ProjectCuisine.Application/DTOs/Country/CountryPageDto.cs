using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.DTOs.Country
{
    public class CountryPageDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string FlagUrl { get; set; } = string.Empty;

        public int RegionId { get; set; }

        public List<RecipeListDto> Recipes { get; set; } = new List<RecipeListDto>();
    }
}
