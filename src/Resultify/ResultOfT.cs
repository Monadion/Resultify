using System;

namespace Resultify;

public sealed class Result<T> : BaseResult
{
    public T? Value { get; }

    private Result(bool isSuccess, Error error, T? value) : base(isSuccess, error)
        => Value = value;

    // Factory Methods
    public static Result<T> Success(T value) => new(true, Error.None, value);
    public static Result<T> Failure(Error error) => new(false, error, default);
    public static Result<T> Try(Func<T> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        try
        {
            var value = func();
            return Success(value);
        }
        catch (Exception ex)
        {
            return Failure(new Error(Code: ex.GetType().Name, Description: ex.Message));
        }
    }

    // Pattern Matching
    public void Match(Action<T?> onSuccess, Action<Error> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        if (IsSuccess)
        {
            onSuccess(Value);
            return;
        }
        onFailure(Error);
    }

    public TResult Match<TResult>(Func<T?, TResult> onSuccess, Func<Error, TResult> onFailure)
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        return IsSuccess
            ? onSuccess(Value)
            : onFailure(Error);
    }

    // Transformations
    public Result<TResult> Map<TResult>(Func<T?, TResult> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return IsSuccess
            ? Result<TResult>.Success(func(Value))
            : Result<TResult>.Failure(Error);
    }

    public Result<TResult> Bind<TResult>(Func<T?, Result<TResult>> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        return IsSuccess
            ? func(Value)
            : Result<TResult>.Failure(Error);
    }
}
