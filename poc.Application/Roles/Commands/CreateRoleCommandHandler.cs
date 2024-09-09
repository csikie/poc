using poc.Application.Abstraction.Messaging;
using poc.Domain.Entities;
using poc.Domain.Interfaces;
using poc.Domain.Interfaces.Repositories;
using poc.Domain.Primitives;

namespace poc.Application.Roles.Commands;

public sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, Result<Role>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }
    
    public Task<Result<Role>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role(request.Name, request.Permissions);
        _roleRepository.Add(role);
        _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Task.FromResult(Result<Role>.Success(role));
    }
}