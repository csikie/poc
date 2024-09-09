using poc.Application.Abstraction.Messaging;
using poc.Domain.Entities;
using poc.Domain.Enums;
using poc.Domain.Primitives;

namespace poc.Application.Roles.Commands;

public sealed record CreateRoleCommand(string Name, Permissions Permissions) : ICommand<Result<Role>>
{
}