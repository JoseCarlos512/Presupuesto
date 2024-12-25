using Presupuestos.Domain.Abstractions;

namespace Presupuestos.Domain.Tests;

public class ResultTests
{
    [Fact]
    public void Success_Should_Return_SuccessResult()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(Error.None,result.Error);
    }

    [Fact]
    public void Success_Should_Return_FailureResult()
    {
        var error = new Error("TestError","Esto es un error");
        var result = Result.Failure(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(error,result.Error);
    }

    [Fact]
    public void Success_Should_Return_SuccessResultWithValue()
    {
        var value = "TestValue";
        var result = Result.Success(value);

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(Error.None,result.Error);
        Assert.Equal(value,result.Value);
    }

}