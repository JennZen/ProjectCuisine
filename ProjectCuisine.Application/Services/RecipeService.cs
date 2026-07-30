using ProjectCuisine.Application.DTOs.Recipe;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Application.Mapping;
using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;

        private readonly RecipeMapper _mapper;

        public RecipeService(IRecipeRepository repository, RecipeMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(RecipeCreateDto recipeDto)
        {
            var foundRecipe = _repository.GetByName(recipeDto.Name);

            if(foundRecipe == null)
            {
                var recipeEntity = _mapper.ToEntity(recipeDto);
                _repository.Add(recipeEntity);
            }
        }

        public void Update(RecipeUpdateDto recipeDto)
        {
            var foundRecipe = _repository.GetById(recipeDto.Id);

            if (foundRecipe != null)
            {
                _mapper.UpdateEntity(recipeDto, foundRecipe);
                _repository.Update(foundRecipe);
            }
        }

        public List<RecipeListDto> GetAll()
        {
            var recipes = _repository.GetAll();
            return _mapper.ToListDtos(recipes);
        }

        public List<RecipeListDto> GetByRegion(int regionId)
        {
            var recipes = _repository.GetByRegion(regionId);
            return _mapper.ToListDtos(recipes);
        }

        public RecipeDetailsDto? GetById(int id)
        {
            var recipe = _repository.GetById(id);
            if (recipe == null)
            {
                return null;
            }
            return _mapper.ToDetailsDto(recipe);
        }

        public void Delete(int id)
        {
            var recipe = _repository.GetById(id);
            if (recipe != null)
            {
                _repository.Delete(recipe);
            }
        }

    }
}
