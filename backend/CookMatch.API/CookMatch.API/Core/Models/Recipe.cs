using CookMatch.API.DataAccess.Entities;
using System.Diagnostics.Eventing.Reader;

namespace CookMatch.API.Core.Models
{
    public class Recipe
    {
        private Recipe(Guid id, string name, List<Ingredient> ingredients)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
        }

        public const int MIN_INGREDIENTS_COUNT = 2;
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Ingredient> Ingredients { get; private set; } = [];

        public static (Recipe Recipe, string Error) Create(Guid id, string name, List<Ingredient> ingredients)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || ingredients.Count < MIN_INGREDIENTS_COUNT)
            {
                error = "Incorrect data";
            }

            var recipe = new Recipe(id, name, ingredients);

            return (recipe, error);
        }
    }

}
