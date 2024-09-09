using MediatR;

namespace poc.Application.Abstraction.Messaging;

/// <summary>
/// Common interface for all commands in the application.
/// </summary>
public interface ICommand : IRequest
{
}

/// <summary>
/// Common interface for all commands in the application with typed results.
/// </summary>
/// <typeparam name="TResult">The type of the result returned by the command.</typeparam>
public interface ICommand<out TResult> : IRequest<TResult>
{
}