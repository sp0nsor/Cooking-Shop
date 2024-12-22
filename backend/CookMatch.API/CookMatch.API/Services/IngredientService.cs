using CookMatch.API.Core.Abstractions.Repositories;
using CookMatch.API.Core.Abstractions.Services;
using CookMatch.API.Core.Models;

namespace CookMatch.API.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public async Task<Guid> Create(Ingredient ingredient, Guid recipeId)
        {
            return await ingredientRepository.Create(ingredient, recipeId);
        }
    }
}
