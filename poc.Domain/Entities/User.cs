using poc.Domain.Primitives;

namespace poc.Domain.Entities;

public sealed class User : Entity
{
    public User()
    {
        
    }
    
    public User(Guid userId, string email)
    {
        UserId = userId;
        Email = email;
    }
    
    public Guid UserId { get; set; }

    public string Email { get; set; }
    
    public IEnumerable<UserRole> UserRoles { get; set; }
}