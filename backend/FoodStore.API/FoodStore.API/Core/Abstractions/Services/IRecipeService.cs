using FoodStore.API.Application.Contracts;

namespace FoodStore.API.Core.Abstractions.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeResponce>> GetRecipes(HttpContext httpContext);
    }
}