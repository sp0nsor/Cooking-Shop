using FoodStore.API.Application.Contracts;

namespace FoodStore.API.Core.Abstractions.Services
{
    public interface IFoodService
    {
        Task<IResult> AddFood(FoodRequest request);
        Task<IResult> GetFoods();
    }
}