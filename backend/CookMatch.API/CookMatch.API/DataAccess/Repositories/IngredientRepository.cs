using CookMatch.API.Core.Abstractions.Repositories;
using CookMatch.API.Core.Models;
using CookMatch.API.DataAccess;
using CookMatch.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookMatch.API.DataAccess.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly CookMatchDbContext context;

        public IngredientRepository(CookMatchDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Create(Ingredient ingredient, Guid recipeId)
        {
            var ingredientEntity = new IngredientEntity
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Unit = ingredient.Unit,
                recipeId = recipeId
            };

            await context.AddAsync(ingredientEntity);
            await context.SaveChangesAsync();

            return ingredientEntity.Id;
        }
    }
}
