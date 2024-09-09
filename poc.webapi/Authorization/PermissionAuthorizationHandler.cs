using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;

namespace poc.webapi.Authorization;

public sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
{
    private const string UserCustomClaimType = "user_metadata";
    
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
    {
        var user = context.User;
        
        var customClaims = context.User.FindFirst(
            c => c.Type == UserCustomClaimType);

        if (customClaims is null)
        {
            return Task.CompletedTask;
        }

        var userCustomClaims = JObject.Parse(customClaims.Value);
        var userPermissions = PolicyNameHelper.GetPermissionsFrom(userCustomClaims["permission"]?.ToObject<string>());

        if ((userPermissions & requirement.Permissions) == 0)
        {
            return Task.CompletedTask;
        }
        
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}