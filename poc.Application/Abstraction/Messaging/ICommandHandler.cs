using MediatR;

namespace poc.Application.Abstraction.Messaging;

/// <summary>
/// Common interface for all command handlers in the application.
/// </summary>
/// <typeparam name="TCommand">The type of the command being handled by the handler.</typeparam>
/// <typeparam name="TResult">The type of the result returned by the command.</typeparam>
public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}

/// <summary>
/// Common interface for all command handlers in the application.
/// </summary>
/// <typeparam name="TCommand">The type of the command being handled by the handler.</typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}