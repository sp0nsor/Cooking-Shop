using Microsoft.EntityFrameworkCore.Storage;

namespace FoodStore.API.Core.Models
{
    public class Food
    {
        private Food(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
        
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public static(Food Food, string Error) Create(Guid id, string name, string description, decimal price)
        {
            var error = string.Empty;

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || price <= 0)
            {
                error = "Incorrect food data";
            }

            var food = new Food(id, name, description, price);

            return (food,  error);
        }
    }
}
