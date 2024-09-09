using poc.Domain.Enums;
using poc.Domain.Primitives;

namespace poc.Domain.Entities;

/// <summary>
/// Represents a role entity.
/// </summary>
public sealed class Role : Entity
{
    public Role() : base()
    {
        Name = string.Empty;
    }
    
    public Role(string name, Permissions permissions) : base()
    {
        Name = name;
        Permissions = permissions;
    }
    
    /// <summary>
    /// Name of the role.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Permissions of the role.
    /// </summary>
    public Permissions Permissions { get; set; }
}