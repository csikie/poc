using poc.Domain.Primitives;

namespace poc.Domain.Interfaces.Repositories;

/// <summary>
/// Base interface for a repository.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public interface IRepository<T>
    where T : Entity
{
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation. The task result contains the list of entities.</returns>
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Gets an entity by its id.
    /// </summary>
    /// <param name="id">The id of the entity.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation. The task result contains the entity.</returns>
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Adds an entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Add(T entity);
}