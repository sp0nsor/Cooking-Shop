using Azure.Core;
using FoodStore.API.Application.Contracts;
using FoodStore.API.Core.Abstractions.Services;
using FoodStore.API.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace FoodStore.API.Endpoints
{
    public static class FoodEndpoints
    {
        public static IEndpointRouteBuilder MapFoodEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("api/foods");

            group.MapPost("/", AddFood);
            group.MapGet("/", GetFoods);
            group.MapPost("/cart", AddToCart);
            group.MapGet("/cart", GetCart);
            group.MapGet("/recipes", GetRecipes);

            return builder;
        }


        private static async Task<IResult> AddFood([FromBody] FoodRequest request, IFoodService foodService)
        {
            var response = await foodService.AddFood(request);

            return response;
        }

        private static async Task<IResult> GetFoods(IFoodService foodService)
        {
            var response = await foodService.GetFoods();

            return response;
        }

        private static IResult AddToCart([FromBody] CartItemRequest request, ICartService cartService, HttpContext httpContext)
        {
            var cart = cartService.GetCartFromCookie(httpContext);

            var cartItem = new CartItem
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = 1,
            };

            cart.AddToCart(cartItem);

            cartService.SetCartCookie(httpContext, cart);

            return Results.Ok();
        }

        private static IResult GetCart(ICartService cartService, HttpContext httpContext)
        {
            var cart = cartService.GetCartFromCookie(httpContext);

            return Results.Ok(cart.Items);
        }

        private static async Task<IResult> GetRecipes(IRecipeService recipeService, HttpContext httpContext)
        {
            var recipes = await recipeService.GetRecipes(httpContext);

            return Results.Ok(recipes);
        }
    }
}
