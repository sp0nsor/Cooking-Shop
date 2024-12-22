using FoodStore.API.Application.Contracts;
using FoodStore.API.Core.Abstractions.Services;
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
    }
}
