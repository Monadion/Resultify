# Samples

All samples below assume:

In your C# code, add:

```c#
using Monadion.Resultify;
```

## Sample 1 — Success (non-generic)

```c#
Result result = Result.Success();

if (result.IsSuccess)
{
    Console.WriteLine("result success");
}
```

## Sample 2 — Failure (non-generic)

```c#
Error error = new Error("Error.Code", " error description");

Result result = Result.Failure(error);

if (result.IsFailure)
{
    Console.WriteLine($"result failure | code: {result.Error.Code}, description: {result.Error.Description}");
}
```

## Sample 3 — Success (generic)

```c#
Result<int> result = Result<int>.Success(1);

if (result.IsSuccess)
{
    Console.WriteLine($"result success | value:{result.Value}");
}
```

## Sample 4 — Failure (generic)

```c#
Error error = new Error("Error.Code", "error description");

Result<int> result = Result<int>.Failure(error);

if (result.IsFailure)
{
    Console.WriteLine($"result failure | code: {result.Error.Code}, description: {result.Error.Description}");
}
```

## Sample 5 — Try + Match (exception-safe)

```c#
Result<int>
    .Try(() => { throw new DivideByZeroException(); })
    .Match(
        success => Console.WriteLine($"success: {success}"),
        failure => Console.WriteLine($"failure: {failure.Description}")
    );
```