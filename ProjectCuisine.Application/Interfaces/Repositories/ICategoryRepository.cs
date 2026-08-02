using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllAsync();
    }
}
