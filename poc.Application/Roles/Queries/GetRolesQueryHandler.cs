using poc.Application.Abstraction.Messaging;
using poc.Domain.Entities;
using poc.Domain.Interfaces.Repositories;
using poc.Domain.Primitives;

namespace poc.Application.Roles.Queries;

public sealed class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, Result<IEnumerable<Role>>>
{
    private readonly IRoleRepository _roleRepository;
    
    public GetRolesQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    
    public async Task<Result<IEnumerable<Role>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllAsync(cancellationToken);
        
        return Result<IEnumerable<Role>>.Success(roles);
    }
}