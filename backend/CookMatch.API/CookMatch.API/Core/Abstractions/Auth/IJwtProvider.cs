using CookMatch.API.Core.Models;

namespace CookMatch.API.Core.Abstractions.Auth
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}