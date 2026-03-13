# Samples

All samples below assume:

In your C# code, add:

```c#
using Monadion.Resultify;
```

## Success Sample (non-generic)

```c#
Result result = Result.Success();

if (result.IsSuccess)
{
    Console.WriteLine("Non Generic result succeeded.");
}
```
## Success Sample (generic)

```c#
Result<int> result = Result<int>.Success(1);

if (result.IsSuccess)
{
    Console.WriteLine($"Generic result succeeded. number: {result.Value}");
}
```

## Failure Sample (non-generic)

```c#
Error error = new Error("Error.Code.Non.Generic", "Non generic rrror description");

Result result = Result.Failure(error);

if (result.IsFailure)
{
    Console.WriteLine($"failure | code: {result.Error.Code}, description: {result.Error.Description}");
}
```

## Failure Sample (generic)

```c#
Error error = new Error("Error.Code.Generic", "Generic error description");

Result<int> result = Result<int>.Failure(error);

if (result.IsFailure)
    Console.WriteLine($"failure | code: {result.Error.Code}, description: {result.Error.Description}");
```

## Try Sample (non-generic)

```c#
var result = Result.Try(() => int.Parse("sample"));

if (result.IsSuccess)
{
    Console.WriteLine("Parsing succeeded.");
}
else
{
    Console.WriteLine($"Parsing failed: {result.Error.Description}");
}
```
## Try Sample (generic)

```c#
var result = Result<int>.Try(() => int.Parse("sample"));

if (result.IsSuccess)
{
    Console.WriteLine($"Parsing succeeded. value: {result.Value}");
}
else
{
    Console.WriteLine($"Parsing failed: {result.Error.Description}");
}
```

## Map Sample (non-generic)

```c#
Result<int> result = Result
    .Success()
    .Map(() => 2 * 2);

if (result.IsSuccess)
    Console.WriteLine($"Mapped value: {result.Value}");
```
## Map Sample (generic)

```c#
Result<int> result = Result<int>
    .Success(1)
    .Map(x => x * 2);

if (result.IsSuccess)
    Console.WriteLine($"Mapped value: {result.Value}");
```

## Bind Sample (non-generic)

```c#
var result =
    Result.Success()
            .Bind(() =>
            {
                Console.WriteLine("Bind executed");
                return Result.Success();
            });

Console.WriteLine(result.IsSuccess
    ? "Pipeline succeeded"
    : "Pipeline failed");
```
## Bind Sample (generic)

```c#
var result =
    Result<int>.Success(1)
            .Bind(x =>
            {
                Console.WriteLine($"Bind executed value: {x}");
                return Result<int>.Success(x);
            });

Console.WriteLine(result.IsSuccess
    ? "Pipeline succeeded"
    : "Pipeline failed");
```

## Pipeline Sample (non-generic)

```c#
string input = "10";

var message =
    Result.Try(() => int.Parse(input))
            .Bind(() => Result.Success())
            .Match(
                () => "success",
                failure => $"Error: {failure.Description}"
            );

Console.WriteLine(message);
```
## Pipeline Sample (generic)

```c#
string input = "10";

var message =
    Result<int>.Try(() => int.Parse(input))
            .Bind((x) => Result<int>.Success(x * 2))
            .Match(
                success => $"success {success}",
                failure => $"Error: {failure.Description}"
            );

Console.WriteLine(message);
```
