using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Infrastructure.Data.Configurations
{
    public class FavoriteRecipeConfiguration : IEntityTypeConfiguration<FavoriteRecipe>
    {
        public void Configure(EntityTypeBuilder<FavoriteRecipe> builder)
        {
            builder.HasKey(fr => new { fr.UserId, fr.RecipeId });

            builder.HasOne(fr => fr.User)
                   .WithMany(u => u.FavoriteRecipes)
                   .HasForeignKey(fr => fr.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fr => fr.Recipe)
                   .WithMany()
                   .HasForeignKey(fr => fr.RecipeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
