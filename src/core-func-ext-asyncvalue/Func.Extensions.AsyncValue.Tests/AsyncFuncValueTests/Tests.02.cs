using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncValueTests
{
    [Fact]
    public void From_02_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, RecordType, CancellationToken, ValueTask<StructType>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.BooleanNullable), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_02_ThenInvokeAsync_ExpectResultOfSourceFunc(
        bool? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncValueFunc.From<RecordType?, StructType, bool?>(
            (_, _, _) => ValueTask.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(MinusFifteenIdNullNameRecord, default, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
