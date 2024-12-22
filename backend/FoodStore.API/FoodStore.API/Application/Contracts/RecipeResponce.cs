namespace FoodStore.API.Application.Contracts
{
    public record RecipeResponce(
        string Name,
        List<IngredientResponse> Ingredients);
}
