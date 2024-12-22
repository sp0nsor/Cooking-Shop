namespace CookMatch.API.Core.Models
{
    public class Ingredient
    {
        private Ingredient(Guid id, string name, int unit)
        {
            Id = id;
            Name = name;
            Unit = unit;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Unit { get; private set; }

        public static(Ingredient Ingredient, string error) Create(Guid id, string name, int unit)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(name) || unit <= 0)
            {
                error = "Incorrect data";
            }

            var ingredient = new Ingredient(id, name, unit);

            return(ingredient,  error);
        }

    }
}
