using FoodStore.API.Core.Models;

namespace FoodStore.API.Core.Abstractions.Repositories
{
    public interface IFoodRepository
    {
        Task<Guid> Create(Food food);
        Task<List<Food>> Get();
    }
}