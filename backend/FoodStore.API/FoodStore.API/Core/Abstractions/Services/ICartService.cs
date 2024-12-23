using FoodStore.API.Core.Models;

namespace FoodStore.API.Core.Abstractions.Services
{
    public interface ICartService
    {
        Cart GetCartFromCookie(HttpContext httpContext);
        void SetCartCookie(HttpContext httpContext, Cart cart);
        void RemoveFromCart(Guid foodId, HttpContext httpContext);
    }
}