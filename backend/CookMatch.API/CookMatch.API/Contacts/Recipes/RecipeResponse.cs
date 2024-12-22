using CookMatch.API.Contacts.Ingredients;

namespace CookMatch.API.Contacts.Recipes
{
    public record RecipeResponse(
        string Name,
        List<IngredientResponse> Ingredients);
}
