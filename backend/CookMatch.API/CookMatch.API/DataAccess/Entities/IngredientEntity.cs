namespace CookMatch.API.DataAccess.Entities
{
    public class IngredientEntity
    {
        public Guid Id { get; set; }
        public Guid recipeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Unit { get; set; }
    }
}
