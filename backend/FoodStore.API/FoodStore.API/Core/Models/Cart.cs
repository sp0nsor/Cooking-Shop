using Microsoft.Identity.Client;

namespace FoodStore.API.Core.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddToCart(CartItem item)
        {
            var cartItem = Items.FirstOrDefault(i => i.Id == item.Id);
            if (cartItem != null)
            {
                cartItem.Quantity += 1;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void RemoveFromCart(Guid foodId)
        {
            var cartItem = Items.FirstOrDefault(i => i.Id == foodId);

            if (cartItem != null)
            {
                Items.Remove(cartItem);
            }
        }
    }
}
