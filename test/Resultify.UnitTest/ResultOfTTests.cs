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
    public void Match_ShouldExecuteCorrectAction_OnSuccess()
    {
        var result = Result<int>.Success(1);
        var successCalled = false;
        var failureCalled = false;

        result.Match(
            (x) => successCalled = true,
            _ => failureCalled = true
        );

        Assert.True(successCalled);
        Assert.False(failureCalled);
    }

    [Fact]
    public void Match_ShouldExecuteCorrectAction_OnFailure()
    {
        var error = new Error("E002");
        var result = Result<int>.Failure(error);
        var successCalled = false;
        var failureCalled = false;
        Error? capturedError = null;

        result.Match(
            (x) => successCalled = true,
            e =>
            {
                failureCalled = true;
                capturedError = e;
            }
        );

        Assert.False(successCalled);
        Assert.True(failureCalled);
        Assert.Equal(error, capturedError);
    }

    [Fact]
    public void Try_ShouldReturnSuccess_WhenNoException()
    {
        var result = Result<int>.Try(() => int.Parse("1"));

        Assert.True(result.IsSuccess);
        Assert.Equal(Error.None, result.Error);
    }

    [Fact]
    public void Try_ShouldReturnFailure_WhenExceptionThrown()
    {
        var result = Result<int>.Try(() => throw new InvalidOperationException("fail"));

        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.Error.Code);
        Assert.Equal("fail", result.Error.Description);
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
