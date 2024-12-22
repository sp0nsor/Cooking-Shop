using FoodStore.API.Core.Abstractions.Services;
using FoodStore.API.Core.Models;
using System.Text.Json;

namespace FoodStore.API.Application.Services
{
    public class CartService : ICartService
    {
        public void SetCartCookie(HttpContext httpContext, Cart cart)
        {
            var options = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            };

            var json = JsonSerializer.Serialize(cart);
            httpContext.Response.Cookies.Append("Cart", json, options);
        }

        public Cart GetCartFromCookie(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies.TryGetValue("Cart", out var cartJson))
            {
                Console.WriteLine($"Cart JSON from cookie: {cartJson}");

                try
                {
                    var cart = JsonSerializer.Deserialize<Cart>(cartJson);
                    if (cart != null)
                    {
                        Console.WriteLine($"Deserialized cart: {JsonSerializer.Serialize(cart)}");
                        return cart;
                    }
                    else
                    {
                        Console.WriteLine("Deserialization resulted in null.");
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Deserialization error: {ex.Message}");
                }
            }

            return new Cart(); // Возвращаем новую корзину, если cookie не найдена
        }
    }
}
