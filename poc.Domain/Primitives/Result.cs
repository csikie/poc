namespace poc.Domain.Primitives;

public class Result
{
    protected Result(Error? error)
    {
        Error = error;
    }
    
    public bool IsSuccess => Error is null;
    
    public Error? Error { get; }
    
    public static Result Success() => new(null);
    
    public static Result Failure(Error error) => new(error);
}

public sealed class Result<T> : Result
{
    private Result(Error? error, T? value) : base(error)
    {
        Value = value;
    }
    
    public T? Value { get; }
    
    public static Result<T> Success(T value) => new(null, value);
    
    public new static Result<T> Failure(Error error) => new(error, default);
}