using System;

namespace Resultify.UnitTest;

public sealed class ResultTests
{
    [Fact]
    public void Success_ShouldBeSuccessful()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(Error.None, result.Error);
    }

    [Fact]
    public void Failure_ShouldBeFailureWithError()
    {
        var error = new Error("E001", "Something went wrong");
        var result = Result.Failure(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void Match_ShouldExecuteCorrectAction_OnSuccess()
    {
        var result = Result.Success();
        var successCalled = false;
        var failureCalled = false;

        result.Match(
            () => successCalled = true,
            _ => failureCalled = true
        );

        Assert.True(successCalled);
        Assert.False(failureCalled);
    }

    [Fact]
    public void Match_ShouldExecuteCorrectAction_OnFailure()
    {
        var error = new Error("E002");
        var result = Result.Failure(error);
        var successCalled = false;
        var failureCalled = false;
        Error? capturedError = null;

        result.Match(
            () => successCalled = true,
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
        var result = Result.Try(() => { /* nothing */ });

        Assert.True(result.IsSuccess);
        Assert.Equal(Error.None, result.Error);
    }

    [Fact]
    public void Try_ShouldReturnFailure_WhenExceptionThrown()
    {
        var result = Result.Try(() => throw new InvalidOperationException("fail"));

        Assert.False(result.IsSuccess);
        Assert.Equal("InvalidOperationException", result.Error.Code);
        Assert.Equal("fail", result.Error.Description);
    }

    [Fact]
    public void Bind_ShouldChainResults_WhenSuccess()
    {
        var result = Result.Success()
            .Bind(() => Result.Success())
            .Bind(() => Result.Failure(new Error("E003")));

        Assert.False(result.IsSuccess);
        Assert.Equal("E003", result.Error.Code);
    }

    [Fact]
    public void Bind_ShouldReturnOriginalFailure_WhenInitialFailure()
    {
        var error = new Error("E004");
        var result = Result.Failure(error)
            .Bind(() => Result.Success());

        Assert.False(result.IsSuccess);
        Assert.Equal(error, result.Error);
    }
}
