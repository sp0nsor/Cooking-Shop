namespace FoodStore.API.Application.Contracts
{
    public record CartItemResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        int Quantity);
}
