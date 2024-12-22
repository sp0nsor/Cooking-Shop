using CookMatch.API.Contacts.Ingredients;

namespace CookMatch.API.Contacts.Recipes
{
    public record RecipeRequest(
        string Name,
        List<IngredientRequest> Ingredients);
}
