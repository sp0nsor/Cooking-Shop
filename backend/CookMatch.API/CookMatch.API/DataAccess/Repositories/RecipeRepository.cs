using CookMatch.API.Contacts;
using CookMatch.API.Core.Abstractions.Repositories;
using CookMatch.API.Core.Models;
using CookMatch.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CookMatch.API.DataAccess.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CookMatchDbContext context;

        public RecipeRepository(CookMatchDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Recipe>> Get(List<string>? ingredients = null)
        {
            var query = context.Recipes
                .Include(r => r.Ingredients)
                .AsQueryable();

            if (ingredients != null && ingredients.Any())
            {
                query = query.Where(r => r.Ingredients.Any(i => ingredients.Contains(i.Name)));
            }

            var recipeEntities = await query.ToListAsync();

            var recipes = recipeEntities
                .Select(r => Recipe.Create(
                    r.Id,
                    r.Name,
                    r.Ingredients
                        .Select(i => Ingredient.Create(i.Id, i.Name, i.Unit).Ingredient)
                        .ToList()
                ).Recipe).ToList();

            return recipes;
        }

        public async Task<Guid> Create(Recipe recipe)
        {
            var recipeEntity = new RecipeEntity
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Ingredients = recipe.Ingredients
                .Select(i => new IngredientEntity 
                { 
                    Id = i.Id,
                    Name = i.Name,
                    Unit = i.Unit,
                    recipeId = recipe.Id
                }).ToList(),
            };

            await context.AddAsync(recipeEntity);
            await context.SaveChangesAsync();

            return recipeEntity.Id;
        }

        public async Task<Guid> Update(Recipe recipe)
        {
            if (!recipe.Ingredients.IsNullOrEmpty())
            {
                var existingIngredients = await context.Ingredients
                .Where(i => i.recipeId == recipe.Id)
                .ToListAsync();

                context.Ingredients.RemoveRange(existingIngredients);

                var newIngredients = recipe.Ingredients
                    .Select(i => new IngredientEntity
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Unit = i.Unit,
                        recipeId = recipe.Id
                    })
                    .ToList();

                await context.Ingredients.AddRangeAsync(newIngredients);
            }

            await context.Recipes.Where(r => r.Id == recipe.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(r => r.Name, recipe.Name));

            await context.SaveChangesAsync();

            return recipe.Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await context.Recipes
                .Where(r => r.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
