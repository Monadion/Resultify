namespace Resultify.Sample.Transform;

public static class MapSample
{
    public static void RunNonGenericMapSample()
    {
        Result<int> result = Result
            .Success()
            .Map(() => 2 * 2);

        if (result.IsSuccess)
            Console.WriteLine($"Mapped value: {result.Value}");
    }

    public static void RunGenericMapSample()
    {
        Result<int> result = Result<int>
            .Success(1)
            .Map(x => x * 2);

        if (result.IsSuccess)
            Console.WriteLine($"Mapped value: {result.Value}");
    }
}
