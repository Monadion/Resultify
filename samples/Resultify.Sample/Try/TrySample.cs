namespace Resultify.Sample.Try;

public static class TrySample
{
    public static void RunNonGenericTrySample()
    {
        var result = Result.Try(() => int.Parse("sample"));

        if (result.IsSuccess)
        {
            Console.WriteLine("Parsing succeeded.");
        }
        else
        {
            Console.WriteLine($"Parsing failed: {result.Error.Description}");
        }
    }

    public static void RunGenericTrySample()
    {
        var result = Result<int>.Try(() => int.Parse("sample"));

        if (result.IsSuccess)
        {
            Console.WriteLine($"Parsing succeeded. value: {result.Value}");
        }
        else
        {
            Console.WriteLine($"Parsing failed: {result.Error.Description}");
        }
    }
}
