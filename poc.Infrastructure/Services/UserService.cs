using Microsoft.AspNetCore.Http;

namespace poc.Infrastructure.Services;

using poc.Application.Abstraction;

/// <inheritdoc cref="IUserService"/>
public sealed class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    private const string UserIdClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
    private const string UserEmailClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";

    /// <inheritdoc />
    public Guid GetUserId()
    {
        var id = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == UserIdClaimType)?.Value
            ?? throw new InvalidOperationException("User is not authenticated");
        
        return Guid.Parse(id);
    }
    
    /// <inheritdoc />
    public string GetUserEmail()
    {
        return httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == UserEmailClaimType)?.Value
            ?? throw new InvalidOperationException("User is not authenticated");
    }
}