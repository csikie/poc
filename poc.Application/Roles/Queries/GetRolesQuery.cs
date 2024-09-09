using poc.Application.Abstraction.Messaging;
using poc.Domain.Entities;
using poc.Domain.Primitives;

namespace poc.Application.Roles.Queries;

public sealed record GetRolesQuery : IQuery<Result<IEnumerable<Role>>>;