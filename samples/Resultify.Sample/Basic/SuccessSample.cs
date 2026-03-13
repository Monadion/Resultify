namespace Resultify.Sample.Basic;

public static class SuccessSample
{
    public static void RunNonGenericSuccessSample()
    {
        Result result = Result.Success();

        if (result.IsSuccess)
        {
            Console.WriteLine("Non Generic result succeeded.");
        }
    }

    public static void RunGenericSuccessSample()
    {
        Result<int> result = Result<int>.Success(1);

        if (result.IsSuccess)
        {
            Console.WriteLine($"Generic result succeeded. number: {result.Value}");
        }
    }
}
