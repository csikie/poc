using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace poc.webapi.Authorization;

public sealed class FlexibleAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    private readonly AuthorizationOptions _options;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="FlexibleAuthorizationPolicyProvider"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public FlexibleAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
        _options = options.Value;
    }
    
    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy != null || !PolicyNameHelper.IsValidPolicyName(policyName)) return policy;
        var permissions = PolicyNameHelper.GetPermissionsFrom(policyName);

        policy = new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionAuthorizationRequirement(permissions))
            .Build();

        _options.AddPolicy(policyName!, policy);

        return policy;
    }
}