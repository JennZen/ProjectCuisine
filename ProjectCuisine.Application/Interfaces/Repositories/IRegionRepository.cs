using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Repositories
{
    public interface IRegionRepository
    {
        public Task<List<Region>> GetAllAsync();

        public Task<Region> GetByIdAsync(int id);

        public Task<int> GetCountAsync();
    }
}
