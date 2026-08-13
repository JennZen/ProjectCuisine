using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Instructions { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
