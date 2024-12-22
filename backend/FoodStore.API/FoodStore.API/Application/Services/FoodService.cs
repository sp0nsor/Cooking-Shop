using FoodStore.API.Application.Contracts;
using FoodStore.API.Core.Abstractions.Repositories;
using FoodStore.API.Core.Abstractions.Services;
using FoodStore.API.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodStore.API.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        public async Task<IResult> GetFoods()
        {
            var foods = await foodRepository.Get();

            var foodsResponse = foods.Select(f =>
            new FoodResponse(f.Id, f.Name, f.Description, f.Price)).ToList();

            return Results.Ok(foodsResponse);
        }

        public async Task<IResult> AddFood(FoodRequest request)
        {
            var (food, error) = Food.Create(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return Results.BadRequest(error);
            }

            var responseId = await foodRepository.Create(food);

            return Results.Ok(responseId);
        }

        public async Task<IResult> AddToCart(FoodRequest request, Guid foodId)
        {
            var (food, error) = Food.Create(foodId, request.Name,
                request.Description, request.Price);

            if(!string.IsNullOrEmpty(error))
            {
                return Results.BadRequest(error);
            }

            return Results.Ok(food);
        }
    }
}
