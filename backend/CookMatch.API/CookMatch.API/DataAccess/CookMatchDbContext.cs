using CookMatch.API.DataAccess.Configurations;
using CookMatch.API.DataAccess.Entities;
using CookMatch.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CookMatch.API.DataAccess
{
    public class CookMatchDbContext : DbContext
    {
        private readonly AuthorizationOptions authOptions;

        public CookMatchDbContext(DbContextOptions<CookMatchDbContext> options,
            IOptions<AuthorizationOptions> authOptions)
            :base(options)
        {
            this.authOptions = authOptions.Value;
        }

        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>()
                .HasMany(r => r.Ingredients)
                .WithOne()
                .HasForeignKey(i => i.recipeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CookMatchDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions)); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
