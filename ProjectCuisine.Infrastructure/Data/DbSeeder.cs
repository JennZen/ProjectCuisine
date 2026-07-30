using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static void Seed(ProjectCuisineDbContext context)
        {
            if (context.Regions.Any()) return;

            var asia = new Region { Name = "Asia", ImageUrl = "https://www.freeworldmaps.net/asia/asia-physical-map.jpg" };
            var europe = new Region { Name = "Europe", ImageUrl = "https://i0.wp.com/mrcozart.files.wordpress.com/2013/03/europe-map-of-europe-physical-relief-wikipedia.png" };
            context.Regions.AddRange(asia, europe);

            var japan = new Country { Name = "Japan", Region = asia, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9e/Flag_of_Japan.svg/1280px-Flag_of_Japan.svg.png" };
            var france = new Country { Name = "France", Region = europe, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/1280px-Flag_of_France.svg.png" };
            var italy = new Country { Name = "Italy", Region = europe, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/0/03/Flag_of_Italy.svg" };
            var moldova = new Country { Name = "Moldova", Region = europe, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/Flag_of_Moldova.svg/330px-Flag_of_Moldova.svg.png" };
            var kazakhstan = new Country { Name = "Kazakhstan", Region = asia, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d3/Flag_of_Kazakhstan.svg" };
            context.Countries.AddRange(japan, france, italy, moldova, kazakhstan);

            var soups = new Category { Name = "Soups" };
            var desserts = new Category { Name = "Desserts" };
            var mainCourses = new Category { Name = "Main Courses" };
            var appetizers = new Category { Name = "Appetizers" };

            context.Categories.AddRange(soups, desserts, mainCourses, appetizers);

            context.Recipes.AddRange(
                new Recipe
                {
                    Name = "Борщ",
                    Description = "Традиционный молдавский суп",
                    Instructions = "1. Сварить бульон...",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpvvVfKY4nnZBNk48S9NXKKqSZZWbyPepbBKgkoQ9WnwOfNxGa0o78RuzAc-6ouyQKl0XxGtxq8WY1mIXzsb9t7W9ZdUAwf6Kgrm3OYKbD&s=10",
                    Category = soups,
                    Country = moldova
                },
                new Recipe
                {
                    Name = "Тирамису",
                    Description = "Классический итальянский десерт",
                    Instructions = "1. Взбить маскарпоне...",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSE5GaFOgwzNkQVLSV10n3IyINQrEkV05ngdDoVLRwa17_sikBWz2nAHuIPq1i2esA5YTI-DpFi0myqZMSBWU7ytLkfj-FUo-bqEIMjEHtMg&s=10",
                    Category = desserts,
                    Country = italy
                }
            );
            context.SaveChanges();
        }
    }
}
