using poc.Application.Abstraction.Messaging;
using poc.Domain.Primitives;

namespace poc.Application.User.Queries;

public sealed record GetUsersQuery : IQuery<Result<IEnumerable<object>>>;