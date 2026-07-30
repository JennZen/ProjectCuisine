using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.DTOs.Recipe
{
    public class RecipeListDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public string CountryName { get; set; } = string.Empty;
    }
}
