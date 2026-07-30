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
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(r => r.Instructions)
                .IsRequired()
                .HasMaxLength(1500);

            builder.Property(r => r.ImageUrl)
                .HasMaxLength(300);

            builder.HasOne(r => r.Category)
            .WithMany(c => c.Recipes)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Country)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
