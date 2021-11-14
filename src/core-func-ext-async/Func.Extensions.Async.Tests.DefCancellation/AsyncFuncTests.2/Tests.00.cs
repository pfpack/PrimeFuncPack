using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests2
{
    [Fact]
    public void From_00_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<Task<StructType>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.String), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_00_ThenInvokeAsync_ExpectResultOfSourceFunc(
        string? sourceFuncResult)
    {
        var actual = AsyncFunc.From(() => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync();

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
