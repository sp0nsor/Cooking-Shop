using CookMatch.API.Core.Models;

namespace CookMatch.API.Core.Abstractions.Services
{
    public interface IRecipeService
    {
        Task<Guid> CreateRecipe(Recipe recipe);
        Task<Guid> DeleteRecipe(Guid id);
        Task<List<Recipe>> GetRecipes(List<string>? ingredients = null);
        Task<Guid> UpdateRecipe(Recipe recipe);
    }
}