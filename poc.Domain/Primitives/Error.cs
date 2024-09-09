using poc.Domain.Enums;

namespace poc.Domain.Primitives;

/// <summary>
/// Represents an error that occurred during the execution of a use case.
/// </summary>
public sealed record Error
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class.
    /// </summary>
    /// <param name="code">Code that represents the error.</param>
    /// <param name="message">Message that describes the error.</param>
    /// <param name="type">Type of the error.</param>
    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }
    
    /// <summary>
    /// Code that represents the error.
    /// </summary>
    public string Code { get; }
    
    /// <summary>
    /// Message that describes the error.
    /// </summary>
    public string Message { get; }
    
    /// <summary>
    /// Type of the error.
    /// </summary>
    public ErrorType Type { get; }
    
    /// <summary>
    /// Represents a not found error.
    /// </summary>
    /// <param name="message">Message that describes the error.</param>
    /// <returns>An instance of the <see cref="Error"/> class that represents a not found error.</returns>
    public static Error NotFound(string message) => new("not_found", message, ErrorType.NotFound);
    
    /// <summary>
    /// Represents a failure error.
    /// </summary>
    /// <param name="message">Message that describes the error.</param>
    /// <returns>An instance of the <see cref="Error"/> class that represents a failure error.</returns>
    public static Error Failure(string message) => new("failure", message, ErrorType.Failure);
    
    /// <summary>
    /// Represents a validation error.
    /// </summary>
    /// <param name="message">Message that describes the error.</param>
    /// <returns>An instance of the <see cref="Error"/> class that represents a validation error.</returns>
    public static Error Validation(string message) => new("validation", message, ErrorType.Validation);
    
    /// <summary>
    /// Represents a conflict error.
    /// </summary>
    /// <param name="message">Message that describes the error.</param>
    /// <returns>An instance of the <see cref="Error"/> class that represents a conflict error.</returns>
    public static Error Conflict(string message) => new("conflict", message, ErrorType.Conflict);
}