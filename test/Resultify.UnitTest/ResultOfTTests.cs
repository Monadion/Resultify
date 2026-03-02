using System;

namespace Resultify.UnitTest;

public sealed class ResultOfTTests
{
    [Fact]
    public void Success_ShouldHoldValue()
    {
        var result = Result<int>.Success(42);

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
        Assert.Equal(Error.None, result.Error);
    }

    [Fact]
    public void Failure_ShouldHaveErrorAndDefaultValue()
    {
        var error = new Error("E005");
        var result = Result<int>.Failure(error);

        Assert.False(result.IsSuccess);
        Assert.Equal(error, result.Error);
        Assert.Equal(default(int), result.Value);
    }

    [Fact]
    public void Map_ShouldTransformValue_WhenSuccess()
    {
        var result = Result<int>.Success(10)
            .Map(x => x * 2);

        Assert.True(result.IsSuccess);
        Assert.Equal(20, result.Value);
    }

    [Fact]
    public void Map_ShouldNotChangeResult_WhenFailure()
    {
        var error = new Error("E006");
        var result = Result<int>.Failure(error)
            .Map(x => x * 2);

        Assert.False(result.IsSuccess);
        Assert.Equal(error, result.Error);
        Assert.Equal(default(int), result.Value);
    }

    [Fact]
    public void Bind_ShouldChainResults_WhenSuccess()
    {
        var result = Result<int>.Success(5)
            .Bind(x => Result<int>.Success(x * 3))
            .Bind(x => Result<int>.Success(x + 2));

        Assert.True(result.IsSuccess);
        Assert.Equal(17, result.Value);
    }

    [Fact]
    public void Bind_ShouldReturnOriginalFailure_WhenInitialFailure()
    {
        var error = new Error("E007");
        var result = Result<int>.Failure(error)
            .Bind(x => Result<int>.Success(x * 3));

        Assert.False(result.IsSuccess);
        Assert.Equal(error, result.Error);
        Assert.Equal(default(int), result.Value);
    }
}
