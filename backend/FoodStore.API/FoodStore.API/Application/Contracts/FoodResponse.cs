namespace FoodStore.API.Application.Contracts
{
    public record FoodResponse(
        Guid Id, 
        string Name,
        string Description,
        decimal Price);
}
