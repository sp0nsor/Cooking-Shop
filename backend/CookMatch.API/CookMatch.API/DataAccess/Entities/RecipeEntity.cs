using CookMatch.API.Core.Models;

namespace CookMatch.API.DataAccess.Entities
{
    public class RecipeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<IngredientEntity> Ingredients { get; set; } = [];
    }
}
