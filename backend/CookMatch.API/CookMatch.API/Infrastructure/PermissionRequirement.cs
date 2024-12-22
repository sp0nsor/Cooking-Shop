﻿using CookMatch.API.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace CookMatch.Infrastructure
{
    public  class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(Permission[] permissions)
        {
            Permissions = permissions;
        }
        public Permission[] Permissions { get; set; } = []; 
    }
}
