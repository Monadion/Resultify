namespace Resultify.Sample.Transform;

public static class BindSample
{
    public static void RunNonGenericBindSample()
    {
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
    }

    public static void RunGenericBindSample()
    {
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
    }
}
