using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncValueFuncTests2
{
    [Fact]
    public void From_06_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, StructType, string, RecordType?, DateTimeKind, object, ValueTask<RecordType>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.String), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_06_ThenInvokeAsync_ExpectResultOfSourceFunc(
        string? sourceFuncResult)
    {
        var actual = AsyncValueFunc.From<RefType, string, StructType?, object, RecordType, int, string?>(
            (_, _, _, _, _, _) => ValueTask.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            MinusFifteenIdRefType, null!, new(), new(), PlusFifteenIdLowerSomeStringNameRecord, int.MaxValue);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
