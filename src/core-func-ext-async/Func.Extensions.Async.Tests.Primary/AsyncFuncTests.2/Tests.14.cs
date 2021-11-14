using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests2
{
    [Fact]
    public void From_14_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<int?, object?, RefType?, RefType, StructType, DateTime, int, RecordType, DateTimeKind, RecordType?, object, string, long, object, Task<RecordType>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.StructType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_14_ThenInvokeAsync_ExpectResultOfSourceFunc(
        StructType sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncFunc.From<int?, RefType, object?, decimal, RecordType?, StructType, long, RefType, int, DateTimeKind, object, long, RefType, int, StructType>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            PlusFifteen, MinusFifteenIdRefType, new(), decimal.MinusOne, MinusFifteenIdSomeStringNameRecord, SomeTextStructType, long.MinValue, PlusFifteenIdRefType, int.MaxValue, DateTimeKind.Utc, null!, long.MinValue, MinusFifteenIdRefType, int.MinValue, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
