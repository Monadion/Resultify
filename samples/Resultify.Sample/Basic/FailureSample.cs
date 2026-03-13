namespace Resultify.Sample.Basic;

public static class FailureSample
{
    public static void RunNonGenericFailureSample()
    {
        Error error = new Error("Error.Code.Non.Generic", "Non generic rrror description");

        Result result = Result.Failure(error);

        if (result.IsFailure)
        {
            Console.WriteLine($"failure | code: {result.Error.Code}, description: {result.Error.Description}");
        }

    }

    public static void RunGenericFailureSample()
    {
        Error error = new Error("Error.Code.Generic", "Generic error description");

        Result<int> result = Result<int>.Failure(error);

        if (result.IsFailure)
            Console.WriteLine($"failure | code: {result.Error.Code}, description: {result.Error.Description}");
    }
}
