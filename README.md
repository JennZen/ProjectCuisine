# ProjectCuisine

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET_Core-MVC-5C2D91?style=flat-square&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity_Framework-Core-6DB33F?style=flat-square&logo=nuget&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![License](https://img.shields.io/badge/status-learning_project-informational?style=flat-square)

**ProjectCuisine** is a web application for exploring recipes from countries and regions around the world, built on ASP.NET Core MVC. It comes with a full admin panel for managing recipes, countries, regions, users, and roles.

---

## Features

### For visitors
- Browse a catalog of recipes
- Open a recipe and see its full details
- Filter by country, region, and category
- Explore countries and regions individually

### For admins
- Create, edit, and delete recipes
- Manage the list of countries and regions
- Manage users and their roles
- View basic project statistics

---

## Tech stack

| Layer | Technology |
|---|---|
| Backend | C#, ASP.NET Core MVC |
| Data access | Entity Framework Core |
| Auth | ASP.NET Core Identity |
| Database | SQL Server |
| Mapping | Mapperly |
| Frontend | Razor Views, Bootstrap, jQuery, HTML/CSS/JS |
| VCS | Git |

---

## Architecture

The project is split into four projects, following Clean Architecture — dependencies point inward, toward `Domain`:

```
ProjectCuisine
│
├── ProjectCuisine.Domain
│   └── Entities
│       Category · Country · FavoriteRecipe · Recipe · Region · User
│
├── ProjectCuisine.Application
│   ├── DTOs            (Category, Country, Recipe, Region, User)
│   ├── Interfaces       (Repositories, Services)
│   ├── Mapping           CategoryMapper · CountryMapper · RecipeMapper · RegionMapper
│   └── Services          CategoryService · CountryService · FavoriteRecipeService ·
│                          RecipeService · RegionService
│
├── ProjectCuisine.Infrastructure
│   ├── Data
│   │   ├── Configurations   (EF Core entity configs)
│   │   ├── DbSeeder.cs
│   │   ├── ProjectCuisineDbContext.cs
│   │   └── RoleSeeder.cs
│   ├── Migrations
│   └── Repositories         CategoryRepository · CountryRepository ·
│                             FavoriteRecipeRepository · RecipeRepository · RegionRepository
│
└── ProjectCuisine.Web
    ├── Controllers          Country · FavoriteRecipe · Home · Recipe · Region · User
    ├── Models               ErrorViewModel, Admin/ (Dashboard, User view models)
    ├── Views                Country · FavoriteRecipe · Home · Recipe · Region · Shared · User
    ├── Areas/Admin
    │   ├── Controllers      Country · Home · Recipe · Region · User
    │   └── Views            (matching admin CRUD pages + _AdminLayout)
    ├── wwwroot              css, js, lib (Bootstrap, jQuery, jQuery Validation)
    └── Program.cs
```

## Core entities

```
User ── Role

Region
 └── Country
      └── Recipe
           └── Category
```

Every recipe belongs to a country, a region, and a category. Users can also mark recipes as favorites (`FavoriteRecipe`).

---

## Getting started

**1. Clone the repo**
```bash
git clone <repository-url>
```

**2. Open the project**
Open the solution in Visual Studio.

**3. Set up the database**
Add your SQL Server connection string to the app configuration.

**4. Apply migrations**
```bash
dotnet ef database update
```

**5. Run it**
```bash
dotnet run
```

---

## Why this project exists

ProjectCuisine started as a hands-on way to learn ASP.NET Core MVC, EF Core, ASP.NET Core Identity, and Clean Architecture — and to actually build something with them instead of just reading about them.
