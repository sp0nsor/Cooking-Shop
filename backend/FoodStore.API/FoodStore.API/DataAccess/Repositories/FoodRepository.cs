using FoodStore.API.Core.Abstractions.Repositories;
using FoodStore.API.Core.Models;
using FoodStore.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodStore.API.DataAccess.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodStoreDbContext context;

        public FoodRepository(FoodStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Food>> Get()
        {
            var foodEntities = await context.Foods
                .AsNoTracking()
                .ToListAsync();

            var foods = foodEntities.Select(f => Food.Create(
                f.Id, f.Name, f.Description, f.Price).Food).ToList();

            return foods;
        }

        public async Task<Guid> Create(Food food)
        {
            var fooodEntity = new FoodEntity
            {
                Id = food.Id,
                Name = food.Name,
                Description = food.Description,
                Price = food.Price,
            };

            await context.Foods.AddAsync(fooodEntity);
            await context.SaveChangesAsync();

            return food.Id;
        }
    }
}
