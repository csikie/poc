namespace poc.Application.Abstraction;

/// <summary>
/// Represents a service that provides information about the current user.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    /// <returns>The user identifier.</returns>
    Guid GetUserId();
    
    /// <summary>
    /// Gets the user email.
    /// </summary>
    /// <returns>The user email.</returns>
    string GetUserEmail();
}