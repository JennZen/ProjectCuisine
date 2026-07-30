using ProjectCuisine.Application.DTOs.Category;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        private readonly CategoryMapper _mapper;

        public CategoryService(ICategoryRepository repository, CategoryMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<CategoryDto> GetAll()
        {
            var categories = _repository.GetAll();
            return _mapper.ToDtos(categories);
        }
    }
}
