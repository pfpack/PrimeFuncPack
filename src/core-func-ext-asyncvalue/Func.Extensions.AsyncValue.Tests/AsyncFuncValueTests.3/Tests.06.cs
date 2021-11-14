using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncValueFuncTests3
{
    [Fact]
    public void From_06_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, StructType, string, RecordType?, DateTimeKind, object, RecordType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.String), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_06_ThenInvokeAsync_ExpectResultOfSourceFunc(
        string? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncValueFunc.From<RefType, string, StructType?, object, RecordType, int, string?>(
            (_, _, _, _, _, _) => sourceFuncResult);

        var actualResult = await actual.InvokeAsync(
            MinusFifteenIdRefType, null!, new(), new(), PlusFifteenIdLowerSomeStringNameRecord, int.MaxValue, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
