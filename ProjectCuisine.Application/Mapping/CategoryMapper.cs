using ProjectCuisine.Application.DTOs.Category;
using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Application.DTOs.Region;
using ProjectCuisine.Domain.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Mapping
{
    [Mapper]
    public partial class CategoryMapper
    {
        public partial CategoryDto ToDto(Category category);
        public partial List<CategoryDto> ToDtos(List<Category> categories);
    }
}
