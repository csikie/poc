using MediatR;

namespace poc.Application.Abstraction.Messaging;

/// <summary>
/// Common interface for all query handlers in the application.
/// </summary>
/// <typeparam name="TQuery">The type of the query being handled by the handler.</typeparam>
/// <typeparam name="TResult">The type of the result returned by the query.</typeparam>
public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    
}