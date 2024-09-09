using Microsoft.EntityFrameworkCore;
using poc.Domain.Interfaces.Repositories;
using poc.Domain.Primitives;

namespace poc.Infrastructure.Persistence.Repositories;

/// <inheritdoc cref="IRepository{T}"/>
public abstract class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly ApplicationDbContext _context;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{T}"/> class.
    /// </summary>
    /// <param name="context">The <see cref="ApplicationDbContext"/>.</param>
    protected Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc/>
    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _context.Set<T>()
            .ToListAsync(cancellationToken);
        
        return entities;
    }
    
    /// <inheritdoc/>
    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<T>()
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        return entity;
    }
    
    /// <inheritdoc/>
    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
}