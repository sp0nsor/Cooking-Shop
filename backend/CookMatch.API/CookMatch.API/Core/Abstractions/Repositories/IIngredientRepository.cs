using CookMatch.API.Core.Models;

namespace CookMatch.API.Core.Abstractions.Repositories
{
    public interface IIngredientRepository
    {
        Task<Guid> Create(Ingredient ingredient, Guid recipeId);
    }
}