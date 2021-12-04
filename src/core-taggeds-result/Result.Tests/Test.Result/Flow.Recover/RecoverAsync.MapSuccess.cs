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
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
        public void RecoverAsyncWithMapSuccess_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var mappedSuccess = int.MaxValue;

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.RecoverAsync<int, SomeError>(null!, _ => Task.FromResult(mappedSuccess)));

            Assert.AreEqual("otherFactoryAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public void RecoverAsyncWithMapSuccess_MapSuccessIsNull_ExpectArgumentNullException(
            Result<RefType, StructType> source)
        {
            var other = new Result<string, SomeError>(SomeString);

            var actualException = Assert.ThrowsAsync<ArgumentNullException>(
                async () => _ = await source.RecoverAsync(_ => Task.FromResult(other), null!));

            Assert.AreEqual("mapSuccessAsync", actualException!.ParamName);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
        public async Task RecoverAsyncWithMapSuccess_SourceIsSuccess_ExpectSuccessResultOfMappedValue(
            Result<RefType, StructType> source)
        {
            var other = new Result<string, SomeError>(EmptyString);
            var mappedSuccess = SomeString;

            var actual = await source.RecoverAsync(_ => Task.FromResult(other), _ => Task.FromResult(mappedSuccess));
            Result<string, SomeError> expected = mappedSuccess;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectOther(
            Result<RefType, StructType> source)
        {
            var other = default(Result<object, SomeError>);
            var mappedSuccess = new object();

            var actual = await source.RecoverAsync(_ => Task.FromResult(other), _ => Task.FromResult(mappedSuccess));
            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
            Result<RefType, StructType> source)
        {
            var other = Result.Success(new SomeRecord()).With<SomeError>();
            var mappedSuccess = new SomeRecord
            {
                Text = "Some property value"
            };

            var actual = await source.RecoverAsync(_ => Task.FromResult(other), _ => Task.FromResult(mappedSuccess));
            Assert.AreEqual(other, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
        public async Task RecoverAsyncWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
            Result<RefType, StructType> source)
        {
            Result<string, SomeError> other = new SomeError(PlusFifteen);
            var mappedValue = "Some success text value";

            var actual = await source.RecoverAsync(_ => Task.FromResult(other), _ => Task.FromResult(mappedValue));
            Assert.AreEqual(other, actual);
        }
    }
}