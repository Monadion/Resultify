namespace Resultify.Sample.Pipelines;

public static class PipelineSample
{
    public static void RunNonGenericPipelineSample()
    {
        string input = "10";

        var message =
            Result.Try(() => int.Parse(input))
                  .Bind(() => Result.Success())
                  .Match(
                      () => "success",
                      failure => $"Error: {failure.Description}"
                  );

        Console.WriteLine(message);
    }

    public static void RunGenericPipelineSample()
    {
        string input = "10";

        var message =
            Result<int>.Try(() => int.Parse(input))
                  .Bind((x) => Result<int>.Success(x * 2))
                  .Match(
                      success => $"success {success}",
                      failure => $"Error: {failure.Description}"
                  );

        Console.WriteLine(message);
    }
}
