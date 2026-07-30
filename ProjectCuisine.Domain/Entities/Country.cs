using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string FlagUrl { get; set; } = string.Empty;

        public int RegionId { get; set; }

        public Region Region { get; set; } = new Region();

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();

    }
}
