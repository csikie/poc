using poc.Domain.Enums;

namespace poc.webapi.Authorization;

/// <summary>
/// Static class to provide permissions
/// </summary>
public static class PermissionsProvider
{
    /// <summary>
    /// Gets all permissions
    /// </summary>
    /// <returns>A <see cref="List{T}"/> of <see cref="Permissions"/></returns>
    public static List<Permissions> GetAll()
    {
        return Enum.GetValues<Permissions>()
            .ToList();
    }
}