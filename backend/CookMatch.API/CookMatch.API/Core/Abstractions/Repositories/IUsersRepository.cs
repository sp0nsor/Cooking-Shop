using CookMatch.API.Core.Enums;
using CookMatch.API.Core.Models;

namespace CookMatch.API.Core.Abstractions.Repositories
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
        Task<ICollection<Permission>> GetUserPermissions(Guid userId);
    }
}
