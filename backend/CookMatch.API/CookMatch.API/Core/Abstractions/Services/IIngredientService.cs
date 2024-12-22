using CookMatch.API.Core.Models;

namespace CookMatch.API.Core.Abstractions.Services
{
    public interface IIngredientService
    {
        Task<Guid> Create(Ingredient ingredient, Guid recipeId);
    }
}