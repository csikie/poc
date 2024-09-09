using poc.Domain.Entities;
using poc.Domain.Interfaces.Repositories;
using poc.Infrastructure.Persistence;
using poc.Infrastructure.Persistence.Repositories;

namespace poc.Infrastructure.Services;

public sealed class UserRoleRepository(ApplicationDbContext context)
    : Repository<UserRole>(context), IUserRoleRepository;