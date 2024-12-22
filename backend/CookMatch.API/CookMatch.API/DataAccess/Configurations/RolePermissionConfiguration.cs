using CookMatch.API.Core.Enums;
using CookMatch.API.DataAccess.Entities;
using CookMatch.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookMatch.API.DataAccess.Configurations
{
    public class RolePermissionConfiguration
        : IEntityTypeConfiguration<RolePermissionEntity>
    {
        private readonly AuthorizationOptions options;

        public RolePermissionConfiguration(AuthorizationOptions options)
        {
            this.options = options;
        }

        public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.PermissionId });

            builder.HasData(ParserolePermissions());
        }

        private RolePermissionEntity[] ParserolePermissions()
        {
            return options.RolePermissions
                .SelectMany(rp => rp.Permissions
                    .Select(p => new RolePermissionEntity
                    {
                        RoleId = (int)Enum.Parse<Role>(rp.Role),
                        PermissionId = (int)Enum.Parse<Permission>(p)
                    })).ToArray();
        }
    }
}
