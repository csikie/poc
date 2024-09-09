using poc.Domain.Interfaces;

namespace poc.Infrastructure.Persistence;

/// <inheritdoc />
internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context">The <see cref="ApplicationDbContext"/>.</param>
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc />
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}