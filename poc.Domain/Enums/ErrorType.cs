namespace poc.Domain.Enums;

/// <summary>
/// Represents the type of error that occurred.
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// Represents a general failure.
    /// </summary>
    Failure,
    
    /// <summary>
    /// Represents a validation error.
    /// </summary>
    Validation,
    
    /// <summary>
    /// Represents an error that occurred because the requested resource was not found.
    /// </summary>
    NotFound,
    
    /// <summary>
    /// Represents an error that occurred because the requested operation is not allowed.
    /// </summary>
    Conflict,
}