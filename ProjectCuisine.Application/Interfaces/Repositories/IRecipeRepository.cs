using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Repositories
{
    public interface IRecipeRepository
    {
        public List<Recipe> GetAll();

        public Recipe? GetById(int id);

        public Recipe? GetByName(string name);

        public List<Recipe> GetByRegion(int regionId);

        public void Add(Recipe recipe);

        public void Update(Recipe recipe);

        public void Delete(Recipe recipe);
    }
}
