using poc.Domain.Primitives;

namespace poc.Domain.Entities;

public sealed class UserRole : Entity
{
    /// <summary>
    /// Timestamp of when the user role was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Id of the role.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Id of the user.
    /// </summary>
    public int UserId { get; set; }

    public User User { get; set; }
    
    public Role Role { get; set; }
}