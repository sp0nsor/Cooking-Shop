using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CookMatch.API.Infrastructure
{
    public class AuthorizationOptions
    {
        public RolePermissions[] RolePermissions { get; set; } = [];
    }

    public class RolePermissions
    {
        public string Role { get; set; } = string.Empty;
        public string[] Permissions { get; set; } = [];
    }
}
