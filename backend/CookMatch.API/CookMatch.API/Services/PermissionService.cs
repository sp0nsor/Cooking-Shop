using CookMatch.API.Core.Abstractions.Repositories;
using CookMatch.API.Core.Enums;

namespace CookMatch.API.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUsersRepository usersRepository;

        public PermissionService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public Task<ICollection<Permission>> GetPermissions(Guid userId)
        {
            return usersRepository.GetUserPermissions(userId);
        }
    }
}
