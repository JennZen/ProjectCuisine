using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Domain.Entities;
using ProjectCuisine.Infrastructure.Data;

namespace ProjectCuisine.Infrastructure.Repositories
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly ProjectCuisineDbContext _context;

        public RecipeRepository(ProjectCuisineDbContext context) 
        { 
            _context = context;
        }
        public void Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void Delete(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }
       
        public List<Recipe> GetAll()
        {
            return _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking().
                ToList();
        }

        public List<Recipe> GetByCountryId(int countryId)
        {
            return _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking().
                Where(r => r.CountryId == countryId).
                ToList();
        }

        public Recipe? GetById(int id)
        {
            return _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking()
                .FirstOrDefault(r => r.Id == id);
        }

        public Recipe? GetByName(string name)
        {
            return _context.Recipes.
                Include(r => r.Category).
                Include(r => r.Country).
                AsNoTracking()
                .FirstOrDefault(r => r.Name == name);
        }

        public void Update(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }
    }
}
