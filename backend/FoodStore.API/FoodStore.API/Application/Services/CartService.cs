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
                Expires = DateTimeOffset.UtcNow.AddDays(30),
            };

            var json = JsonSerializer.Serialize(cart);
            httpContext.Response.Cookies.Append("Cart", json, options);
        }

        public Cart GetCartFromCookie(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies.TryGetValue("Cart", out var cartJson))
            {
                try
                {
                    var cart = JsonSerializer.Deserialize<Cart>(cartJson);
                    if (cart != null)
                    {
                        return cart;
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Deserialization error: {ex.Message}");
                }
            }

            return new Cart();
        }

        public void RemoveFromCart(Guid foodId, HttpContext httpContext)
        {
            var cart = GetCartFromCookie(httpContext);

            cart.RemoveFromCart(foodId);

            SetCartCookie(httpContext, cart);
        }
    }
}
