using CookMatch.API.Contacts;
using CookMatch.API.Contacts.Ingredients;
using CookMatch.API.Contacts.Recipes;
using CookMatch.API.Core.Abstractions.Services;
using CookMatch.API.Core.Enums;
using CookMatch.API.Core.Models;
using CookMatch.API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CookMatch.API.Endpoints
{
    public static class RecipesEndpoints
    {
        public static IEndpointRouteBuilder MapRecipesEndpoits(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("api/Recipes").RequireAuthorization();

            group.MapPost("/", CreatRecipe).RequirePermission(Permission.Create); ;
            group.MapGet("/", GetRecipes).RequirePermission(Permission.Read);
            group.MapDelete("/{id:guid}", DeleteRecipe).RequirePermission(Permission.Delete); ;
            group.MapPut("/{id:guid}", UpdateRecipe).RequirePermission(Permission.Update); ;

            return builder;
        }

        private static async Task<IResult> GetRecipes(IRecipeService recipeService, [FromBody] List<string>? ingredients)
        {
            var recipes = await recipeService.GetRecipes(ingredients);
            var response = recipes.Select(r => new RecipeResponse(
                r.Name, 
                r.Ingredients.Select(i => new IngredientResponse ( i.Name, i.Unit))
                .ToList()));

            return Results.Ok(response);
        }

        private static async Task<IResult> CreatRecipe(
            [FromBody] RecipeRequest request,
            IRecipeService recipeService)
        {
            var ingredientsRequest = request.Ingredients;
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (var ingredientRequest in ingredientsRequest)
            {
                var (ingredient, ingError) = Ingredient.Create(
                    Guid.NewGuid(),
                    ingredientRequest.Name,
                    ingredientRequest.Unit);

                if (!string.IsNullOrEmpty(ingError))
                {
                    return Results.BadRequest(ingError);
                }

                ingredients.Add(ingredient);
            }

            var (recipe, recipeError) = Recipe.Create(
                Guid.NewGuid(),
                request.Name,
                ingredients);

            if (!string.IsNullOrEmpty(recipeError))
            {
                return Results.BadRequest(recipeError);
            }

            var recipeId = await recipeService.CreateRecipe(recipe);

            return Results.Ok(recipeId);
        }


        private static async Task<IResult> UpdateRecipe(Guid id, [FromBody] RecipeRequest request, IRecipeService recipeService)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach(var i in request.Ingredients)
            {
                var(ing, ingError) = Ingredient.Create(Guid.NewGuid(), i.Name, i.Unit);
                if (!string.IsNullOrEmpty(ingError))
                {
                    return Results.BadRequest(ingError);
                }
                ingredients.Add(ing);
            }

            var (recipe, recipeError) = Recipe.Create(id, request.Name, ingredients);
            if (!string.IsNullOrEmpty(recipeError))
            {
                return Results.BadRequest(recipeError);
            }

            var bookId = await recipeService.UpdateRecipe(recipe);

            return Results.Ok();
        }

        private static async Task<IResult> DeleteRecipe(Guid id, IRecipeService recipeService)
        {
            var recipeId = await recipeService.DeleteRecipe(id);

            return Results.Ok(id);
        }
    } 
}
