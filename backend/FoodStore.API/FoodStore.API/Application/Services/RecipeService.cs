using FoodStore.API.Application.Contracts;
using FoodStore.API.Core.Abstractions.Services;

namespace FoodStore.API.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ICartService cartService;
        private readonly HttpClient httpClient;

        public RecipeService(ICartService cartService, HttpClient httpClient)
        {
            this.cartService = cartService;
            this.httpClient = httpClient;
        }
        public async Task<List<RecipeResponce>> GetRecipes(HttpContext httpContext)
        {
            var cart = cartService.GetCartFromCookie(httpContext);

            List<string> ingredientsName = new List<string>();

            foreach(var ingredient in cart.Items)
            {
                ingredientsName.Add(ingredient.Name);
            }

            var respose = await httpClient.PostAsJsonAsync("api/Recipes/get", ingredientsName);
            
            if(respose.IsSuccessStatusCode)
            {
                var recipes = await respose.Content.ReadFromJsonAsync<List<RecipeResponce>>();

                return recipes;
            }

            Console.WriteLine("хуй хуй хуй хуй хуй хуй");
            return new List<RecipeResponce>();
        }
    }
}
