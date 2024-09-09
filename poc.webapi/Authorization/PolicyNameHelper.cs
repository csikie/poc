using poc.Domain.Enums;

namespace poc.webapi.Authorization;

public static class PolicyNameHelper
{
    private const string PolicyPrefix = "Permission";
    
    /// <summary>
    /// Determines whether the specified policy name is valid.
    /// </summary>
    /// <param name="policyName">Name of the policy.</param>
    /// <returns>The result of the validation.</returns>
    public static bool IsValidPolicyName(string? policyName)
    {
        return policyName is not null && policyName.StartsWith(PolicyPrefix, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Generates the name of the policy for.
    /// </summary>
    /// <param name="permissions">The permissions.</param>
    /// <returns>The generated policy name.</returns>
    public static string GeneratePolicyNameFor(Permissions permissions)
    {
        return $"{PolicyPrefix}{(int)permissions}";
    }

    /// <summary>
    /// Gets the permissions from the specified policy name.
    /// </summary>
    /// <param name="policyName">Name of the policy.</param>
    /// <returns>The permissions.</returns>
    public static Permissions GetPermissionsFrom(string? policyName)
    {
        if (policyName is null || !IsValidPolicyName(policyName))
        {
            throw new ArgumentException("Invalid policy name.", nameof(policyName));
        }
        
        var permissionsValue = int.Parse(policyName[PolicyPrefix.Length..]!);

        return (Permissions)permissionsValue;
    }
}