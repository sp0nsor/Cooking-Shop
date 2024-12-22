namespace FoodStore.API.Application.Contracts
{
    public record CartItemRequest(
        Guid Id,
        string Name,
        string Description, 
        decimal Price);
}
