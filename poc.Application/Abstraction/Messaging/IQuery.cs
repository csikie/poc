using MediatR;

namespace poc.Application.Abstraction.Messaging;

/// <summary>
/// Common interface for all queries in the application.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IQuery<out T> : IRequest<T>
{
}