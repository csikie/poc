namespace poc.Domain.Interfaces;

/// <summary>
/// Base interface for Unit of Work pattern.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Save changes to the database.
    /// </summary>
    /// <param name="cancellationToken"> A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}