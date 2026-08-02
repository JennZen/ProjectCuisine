using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Repositories
{
    public interface ICountryRepository
    {
        public Task<List<Country>> GetAllAsync();

        public Task<Country?> GetByIdAsync(int id);

        public Task<List<Country>> GetAllByRegionAsync(int regionId);
    }
}
