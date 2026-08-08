using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Infrastructure.Data
{
    public class ProjectCuisineDbContext : IdentityDbContext<User>
    {
        public ProjectCuisineDbContext(
            DbContextOptions<ProjectCuisineDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<FavoriteRecipe> FavoriteRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectCuisineDbContext).Assembly);
        }
    }
}
