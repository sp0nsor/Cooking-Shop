namespace CookMatch.API.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<string> Login(string email, string password);
        Task Register(string name, string email, string password);
    }
}