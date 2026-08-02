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
        public Task<List<Recipe>> GetAllAsync();

        public Task<Recipe?> GetByIdAsync(int id);

        public Task<Recipe?> GetByNameAsync(string name);

        public Task<List<Recipe>> GetByCountryIdAsync(int countryId);

        public Task AddAsync(Recipe recipe);

        public Task UpdateAsync(Recipe recipe);

        public Task DeleteAsync(Recipe recipe);
    }
}
