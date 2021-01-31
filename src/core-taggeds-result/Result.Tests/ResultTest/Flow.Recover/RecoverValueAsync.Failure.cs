#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void RecoverValueAsyncFailure_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.RecoverValueAsync<SomeError>(null!));

            Assert.AreEqual("otherFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        public async Task RecoverValueAsyncFailure_SourceIsNullSuccess_ExpectSuccessResultOfSourceValue(
            Result<RefType?, StructType> source)
        {
            var other = new Result<RefType?, SomeError>(PlusFifteenIdRefType);

            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));
            var expected = new Result<RefType?, SomeError>(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public async Task RecoverValueAsyncFailure_SourceIsNotNullSuccess_ExpectSuccessResultOfSourceValue(
            Result<RefType, StructType> source)
        {
            var other = new Result<RefType, SomeError>(new SomeError(int.MinValue));

            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));
            var expected = new Result<RefType, SomeError>(PlusFifteenIdRefType);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverValueAsyncFailure_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectOther(
            Result<RefType, StructType> source)
        {
            Result<RefType, int> other = int.MaxValue;
            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverValueAsyncFailure_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
            Result<RefType, StructType> source)
        {
            var other = Result.Success(ZeroIdRefType).With<decimal>();
            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverValueAsyncFailure_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
            Result<RefType, StructType> source)
        {
            Result<RefType, SomeError> other = new SomeError(PlusFifteen);
            var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

            Assert.AreEqual(other, actual);
        }
    }
}