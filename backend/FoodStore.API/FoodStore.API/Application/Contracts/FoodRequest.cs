using System.Globalization;

namespace FoodStore.API.Application.Contracts
{
    public record FoodRequest(
        string Name,
        string Description,
        decimal Price);
}
