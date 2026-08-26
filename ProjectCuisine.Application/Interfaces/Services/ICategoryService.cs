using ProjectCuisine.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllAsync();

        public Task<CategoryDto?> GetByIdAsync(int id);
    }
}
