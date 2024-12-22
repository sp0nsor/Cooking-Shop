using FoodStore.API.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodStore.API.DataAccess
{
    public class FoodStoreDbContext : DbContext
    {
        public FoodStoreDbContext(DbContextOptions<FoodStoreDbContext> options)
            : base(options) { }

        public DbSet<FoodEntity> Foods { get; set; }
    }
}
