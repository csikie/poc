using poc.Application.Abstraction.Messaging;
using poc.Domain.Interfaces.Repositories;
using poc.Domain.Primitives;

namespace poc.Application.User.Queries;

public sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, Result<IEnumerable<object>>>
{
    private readonly IUserRepository _userRepository;
    
    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Result<IEnumerable<object>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var mapped = users.Select(x => new
        {
            x.Email,
            x.UserId,
            Roles = x.UserRoles.Select(y => y.Role.Name).ToList(),
        });
        
        return Result<IEnumerable<object>>.Success(mapped);
    }
}