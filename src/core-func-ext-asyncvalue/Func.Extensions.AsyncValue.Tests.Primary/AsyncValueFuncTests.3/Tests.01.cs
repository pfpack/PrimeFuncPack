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
    public void From_01_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<StructType?, RefType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncValueFunc.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.RecordRefType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_01_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RecordType? sourceFuncResult, CancellationToken sourceFuncCancellationToken)
    {
        var actual = AsyncValueFunc.From<RefType, RecordType?>(_ => sourceFuncResult);

        var actualResult = await actual.InvokeAsync(PlusFifteenIdRefType, sourceFuncCancellationToken);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
