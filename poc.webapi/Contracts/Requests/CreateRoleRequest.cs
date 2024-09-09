using poc.Domain.Enums;

namespace poc.Contracts.Requests;

public sealed class CreateRoleRequest
{
    public required string Name { get; set; }
    
    public required Permissions Permissions { get; set; }
}