using MediatR;
using Microsoft.Extensions.Logging;
using poc.Application.Abstraction;
using poc.Domain.Primitives;

namespace poc.Application.Behaviors;

/// <summary>
/// Represents a pipeline behavior that logs requests and responses.
/// </summary>
/// <param name="loggerFactory">The logger factory for creating logger.</param>
/// <param name="userService">The user service for getting user information.</param>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(ILoggerFactory loggerFactory, IUserService userService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>>
        _logger = loggerFactory.CreateLogger<RequestLoggingPipelineBehavior<TRequest, TResponse>>();
    private readonly IUserService _userService = userService;
    
    /// <inheritdoc />
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _userService.GetUserId();
        var userEmail = _userService.GetUserEmail();
        _logger.LogInformation("Handling {RequestName} for user {UserId} ({UserEmail})", requestName, userId, userEmail);
        
        var result = await next();
        if (result.IsSuccess)
        {
            _logger.LogInformation("Handled {RequestName} successfully with response {@Response}", requestName, result);
            return result;
        }
        else
        {
            _logger.LogError("Handled {RequestName} with error {@Error}", requestName, result.Error);
            return result;
            
            // Other logging options could be: Serilog, Application Insights, etc.
        }
    }
}