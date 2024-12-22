using CookMatch.API.Core.Enums;

namespace CookMatch.API.Services
{
    public interface IPermissionService
    {
        Task<ICollection<Permission>> GetPermissions(Guid userId);
    }
}