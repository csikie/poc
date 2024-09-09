using Microsoft.AspNetCore.Authorization;
using poc.Domain.Enums;

namespace poc.webapi.Authorization;

public sealed class PermissionAuthorizationRequirement : IAuthorizationRequirement
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionAuthorizationRequirement"/> class.
    /// </summary>
    /// <param name="permissions">The permissions.</param>
    public PermissionAuthorizationRequirement(Permissions permissions)
    {
        Permissions = permissions;
    }

    public Permissions Permissions { get; set; }
}