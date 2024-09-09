using MediatR;
using Microsoft.Extensions.Logging;

namespace poc.Application.Behaviors;

/// <summary>
/// Represents a pipeline behavior that handles exceptions.
/// </summary>
/// <param name="loggerFactory">The logger factory for creating logger.</param>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
internal sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(ILoggerFactory loggerFactory)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            var logger = loggerFactory.CreateLogger<TRequest>();
            logger.LogError(ex, "Error handling {RequestName}", requestName);

            throw;
        }
    }
}