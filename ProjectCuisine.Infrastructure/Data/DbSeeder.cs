using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCuisine.Infrastructure.Data
{
    public static class DbSeeder
    {
        public async static Task SeedAsync(ProjectCuisineDbContext context)
        {
            if (context.Recipes.Any()) context.Recipes.RemoveRange(context.Recipes);
            if (context.Categories.Any()) context.Categories.RemoveRange(context.Categories);
            if (context.Countries.Any()) context.Countries.RemoveRange(context.Countries);
            if (context.Regions.Any()) context.Regions.RemoveRange(context.Regions);

            await context.SaveChangesAsync();

            // 1. Regions
            var oceania = new Region { Name = "Oceania", ImageUrl = "https://www.virtualoceania.net/oceania/maps/globe.gif" };
            var southAmerica = new Region { Name = "South America", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0f/South_America_%28orthographic_projection%29.svg/960px-South_America_%28orthographic_projection%29.svg.png?_=20120912202456" };
            var northAmerica = new Region { Name = "North America", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e3/North_America_on_the_globe_%28North_America_centered%29.svg/3840px-North_America_on_the_globe_%28North_America_centered%29.svg.png" };
            var africa = new Region { Name = "Africa", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/86/Africa_%28orthographic_projection%29.svg/960px-Africa_%28orthographic_projection%29.svg.png?_=20260215153236" };
            var asia = new Region { Name = "Asia", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Asia_on_the_globe_%28red%29.svg/1280px-Asia_on_the_globe_%28red%29.svg.png" };
            var europe = new Region { Name = "Europe", ImageUrl = "https://www.clipartmax.com/png/middle/265-2659990_avrupa-konseyine-%C3%BCye-%C3%BClkeler-europe-globe.png" };

            await context.Regions.AddRangeAsync(europe, asia, africa, northAmerica, southAmerica, oceania);

            // Europe
            var france = new Country { Name = "France", Region = europe, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/1280px-Flag_of_France.svg.png" };
            var italy = new Country { Name = "Italy", Region = europe, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/0/03/Flag_of_Italy.svg" };
            var moldova = new Country { Name = "Moldova", Region = europe, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/Flag_of_Moldova.svg/330px-Flag_of_Moldova.svg.png" };
            var spain = new Country { Name = "Spain", Region = europe, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/9/9a/Flag_of_Spain.svg" };
            var germany = new Country { Name = "Germany", Region = europe, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/b/ba/Flag_of_Germany.svg" };

            // Asia
            var japan = new Country { Name = "Japan", Region = asia, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9e/Flag_of_Japan.svg/1280px-Flag_of_Japan.svg.png" };
            var kazakhstan = new Country { Name = "Kazakhstan", Region = asia, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d3/Flag_of_Kazakhstan.svg" };
            var china = new Country { Name = "China", Region = asia, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/f/fa/Flag_of_the_People%27s_Republic_of_China.svg" };
            var india = new Country { Name = "India", Region = asia, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/4/41/Flag_of_India.svg" };
            var thailand = new Country { Name = "Thailand", Region = asia, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a9/Flag_of_Thailand.svg" };

            // Africa
            var egypt = new Country { Name = "Egypt", Region = africa, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/f/fe/Flag_of_Egypt.svg" };
            var morocco = new Country { Name = "Morocco", Region = africa, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Flag_of_Morocco.svg" };
            var nigeria = new Country { Name = "Nigeria", Region = africa, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/7/79/Flag_of_Nigeria.svg" };
            var southAfrica = new Country { Name = "South Africa", Region = africa, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/a/af/Flag_of_South_Africa.svg" };

            // North America
            var usa = new Country { Name = "United States", Region = northAmerica, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Flag_of_the_United_States.svg" };
            var mexico = new Country { Name = "Mexico", Region = northAmerica, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/f/fc/Flag_of_Mexico.svg" };
            var canada = new Country { Name = "Canada", Region = northAmerica, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d9/Flag_of_Canada_%28Pantone%29.svg" };
            var jamaica = new Country { Name = "Jamaica", Region = northAmerica, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/0/0a/Flag_of_Jamaica.svg" };

            // South America
            var brazil = new Country { Name = "Brazil", Region = southAmerica, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/0/05/Flag_of_Brazil.svg" };
            var argentina = new Country { Name = "Argentina", Region = southAmerica, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/1/1a/Flag_of_Argentina.svg" };
            var peru = new Country { Name = "Peru", Region = southAmerica, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/c/cf/Flag_of_Peru.svg" };
            var colombia = new Country { Name = "Colombia", Region = southAmerica, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/2/21/Flag_of_Colombia.svg" };

            // Oceania
            var australia = new Country { Name = "Australia", Region = oceania, FlagUrl = "https://upload.wikimedia.org/wikipedia/en/b/b9/Flag_of_Australia.svg" };
            var newZealand = new Country { Name = "New Zealand", Region = oceania, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3e/Flag_of_New_Zealand.svg" };
            var fiji = new Country { Name = "Fiji", Region = oceania, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/b/ba/Flag_of_Fiji.svg" };
            var samoa = new Country { Name = "Samoa", Region = oceania, FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/3/31/Flag_of_Samoa.svg" };

            await context.Countries.AddRangeAsync(
                france, italy, moldova, spain, germany,
                japan, kazakhstan, china, india, thailand,
                egypt, morocco, nigeria, southAfrica,
                usa, mexico, canada, jamaica,
                brazil, argentina, peru, colombia,
                australia, newZealand, fiji, samoa
            );

            // 3. Categories
            var soups = new Category { Name = "Soups" };
            var desserts = new Category { Name = "Desserts" };
            var mainCourses = new Category { Name = "Main Courses" };
            var appetizers = new Category { Name = "Appetizers" };
            var salads = new Category { Name = "Salads" };
            var bakery = new Category { Name = "Bakery & Bread" };
            var drinks = new Category { Name = "Beverages" };
            var sauces = new Category { Name = "Sauces & Condiments" };

            await context.Categories.AddRangeAsync(soups, desserts, mainCourses, appetizers, salads, bakery, drinks, sauces);

            // 4. Recipes
            await context.Recipes.AddRangeAsync(
                new Recipe
                {
                    Name = "Classic Tiramisu",
                    Description = "An iconic Italian dessert made of ladyfingers dipped in coffee, layered with a whipped mixture of eggs, sugar, and mascarpone cheese.",
                    Instructions = "1. Whisk egg yolks and sugar until thick and pale.\n" +
                                   "2. Fold mascarpone cheese into the egg mixture until smooth.\n" +
                                   "3. Quickly dip ladyfingers into cooled brewed espresso.\n" +
                                   "4. Layer dipped ladyfingers and mascarpone cream in a dish.\n" +
                                   "5. Refrigerate for at least 4 hours and dust with cocoa powder before serving.",
                    ImageUrl = "https://i.namu.wiki/i/XBumdCFesfCuKvC7TG5VpuvjwXEnlSX47D5mS5iGD292Yw2Sm3zl0nyNsz_KPhg89LeUZkZMtLEfgTIWfBA6qg.webp",
                    Category = desserts,
                    Country = italy
                },
                new Recipe
                {
                    Name = "Shoyu Ramen",
                    Description = "A classic Japanese noodle soup served in a flavorful soy sauce-based chicken and pork broth.",
                    Instructions = "1. Prepare the soy sauce tare base by simmering dashi, soy sauce, and mirin.\n" +
                                   "2. Boil ramen noodles according to package instructions and drain.\n" +
                                   "3. Pour hot chicken broth combined with tare into a serving bowl.\n" +
                                   "4. Add cooked noodles into the broth.\n" +
                                   "5. Top with sliced chashu pork, soft-boiled marinated egg, nori, and chopped green onions.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/Shoyu_Ramen%EF%BC%88Tokyo_Ramen%EF%BC%89_-_01.jpg/1280px-Shoyu_Ramen%EF%BC%88Tokyo_Ramen%EF%BC%89_-_01.jpg",
                    Category = soups,
                    Country = japan
                },
                new Recipe
                {
                    Name = "Chicken Tikka Masala",
                    Description = "A popular dish of roasted marinated chicken chunks in a spiced, creamy tomato sauce.",
                    Instructions = "1. Marinate chicken pieces in yogurt and aromatic spices for 1 hour.\n" +
                                   "2. Grill or sear chicken until lightly charred.\n" +
                                   "3. Sauté onions, garlic, and ginger, then add tomato purée and spices.\n" +
                                   "4. Simmer until the sauce thickens, then stir in heavy cream.\n" +
                                   "5. Add cooked chicken to the sauce and simmer for 10 minutes before serving with basmati rice.",
                    ImageUrl = "https://i.namu.wiki/i/WXxEvDJPE1qvJpop78fFyMKr9z9Jztpj0vC92Kzu9500zTyFEfhnC7G-mHkjMmXmh17MnkzPPgjvqk1zN2nzag.webp",
                    Category = mainCourses,
                    Country = india
                },
                new Recipe
                {
                    Name = "Guacamole",
                    Description = "A traditional Mexican avocado-based dip enriched with fresh lime juice, cilantro, onions, and tomatoes.",
                    Instructions = "1. Slice avocados in half, remove seeds, and scoop the flesh into a bowl.\n" +
                                   "2. Mash avocados coarsely with a fork.\n" +
                                   "3. Stir in finely diced onions, jalapeños, tomatoes, and fresh cilantro.\n" +
                                   "4. Add fresh lime juice and season generously with salt.\n" +
                                   "5. Serve immediately with crispy tortilla chips.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2a/Guacamole_IMGP1265.jpg",
                    Category = appetizers,
                    Country = mexico
                },
                new Recipe
                {
                    Name = "Tom Yum Goong",
                    Description = "A famous Thai hot and sour soup cooked with shrimp, lemongrass, galangal, kaffir lime leaves, and chili.",
                    Instructions = "1. Bring water or light chicken stock to a gentle boil.\n" +
                                   "2. Add bruised lemongrass, galangal slices, and torn kaffir lime leaves.\n" +
                                   "3. Stir in mushrooms and Thai chili paste.\n" +
                                   "4. Add fresh shrimp and simmer until just cooked through.\n" +
                                   "5. Remove from heat, stir in lime juice and fish sauce, and garnish with fresh cilantro.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/e8/Tom_yam_kung_maenam.jpg",
                    Category = soups,
                    Country = thailand
                },
                new Recipe
                {
                    Name = "Spanish Paella",
                    Description = "A traditional Spanish rice dish cooked in a shallow pan with saffron, vegetables, and seafood or meat.",
                    Instructions = "1. Heat olive oil in a wide paella pan and brown chicken or seafood.\n" +
                                   "2. Sauté chopped onions, garlic, bell peppers, and grated tomatoes.\n" +
                                   "3. Stir in bomba rice and saffron-infused warm broth.\n" +
                                   "4. Cook without stirring until rice absorbs liquid and forms a crust on the bottom.\n" +
                                   "5. Garnish with lemon wedges and fresh parsley before serving.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ed/01_Paella_Valenciana_original.jpg",
                    Category = mainCourses,
                    Country = spain
                },
                new Recipe
                {
                    Name = "Greek Salad",
                    Description = "A crisp and refreshing salad made of tomatoes, cucumbers, red onion, olives, and a slice of feta cheese.",
                    Instructions = "1. Chop ripe tomatoes, cucumbers, and green bell peppers into bite-sized pieces.\n" +
                                   "2. Thinly slice red onion and place all vegetables in a bowl.\n" +
                                   "3. Add Kalamata olives and top with a thick slab of feta cheese.\n" +
                                   "4. Drizzle generously with extra virgin olive oil.\n" +
                                   "5. Sprinkle dried oregano and pinch of sea salt over the salad.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f2/Greece_Food_Horiatiki.JPG",
                    Category = salads,
                    Country = france 
                },
                new Recipe
                {
                    Name = "French Onion Soup",
                    Description = "A rich French soup based on meat stock and caramelized onions, topped with toasted bread and melted cheese.",
                    Instructions = "1. Slowly caramelize thinly sliced onions in butter for 45 minutes until golden brown.\n" +
                                   "2. Deglaze the pot with white wine and stir well.\n" +
                                   "3. Add rich beef broth and simmer for 20 minutes.\n" +
                                   "4. Ladle soup into oven-safe bowls and top with a slice of toasted baguette.\n" +
                                   "5. Cover with Gruyère cheese and broil until golden and bubbly.",
                    ImageUrl = "https://www.afmelbourne.com.au/media/website_pages/blog-and-media/blog/french-recipes/onion-soup/french-onion-soup-90b5c39f9f734197ac5d08c66a4e4bb3_497x331a.jpg",
                    Category = soups,
                    Country = france
                },
                new Recipe
                {
                    Name = "Ceviche",
                    Description = "A fresh South American dish of fresh raw fish cured in fresh citrus juices, spiced with chili peppers.",
                    Instructions = "1. Cut fresh white fish fillet into bite-sized cubes.\n" +
                                   "2. Place fish in a glass bowl and cover completely with fresh lime juice.\n" +
                                   "3. Marinate in the refrigerator for 20-30 minutes until fish turns opaque.\n" +
                                   "4. Mix in thinly sliced red onions, finely chopped habanero, and fresh cilantro.\n" +
                                   "5. Serve chilled alongside sweet corn and sweet potato slices.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/78/Cebiche_de_corvina.JPG",
                    Category = appetizers,
                    Country = peru
                },
                new Recipe
                {
                    Name = "Pancakes with Maple Syrup",
                    Description = "Fluffy North American breakfast pancakes served warm with butter and pure maple syrup.",
                    Instructions = "1. Whisk flour, sugar, baking powder, and salt in a bowl.\n" +
                                   "2. In another bowl, combine milk, eggs, and melted butter.\n" +
                                   "3. Mix wet and dry ingredients together until just combined.\n" +
                                   "4. Pour batter onto a hot greased griddle and cook until bubbles form on top.\n" +
                                   "5. Flip and cook until golden brown, then serve stacked with butter and warm maple syrup.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e8/Pancake_with_maple_syrup_1.jpg/1280px-Pancake_with_maple_syrup_1.jpg",
                    Category = bakery,
                    Country = canada
                }
            );

            await context.SaveChangesAsync();
        }
    }
}