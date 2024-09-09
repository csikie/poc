using Microsoft.EntityFrameworkCore;
using poc.Domain.Entities;
using poc.Domain.Interfaces.Repositories;
using poc.Infrastructure.Persistence;
using poc.Infrastructure.Persistence.Repositories;

namespace poc.Infrastructure.Services;

public sealed class UserRepository(ApplicationDbContext context) : Repository<User>(context), IUserRepository
{
    public override async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<User>()
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .AsSplitQuery()
            .ToListAsync(cancellationToken);
    }
}