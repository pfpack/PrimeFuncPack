﻿#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Data;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.Tests
{
    partial class PipelineExtensionsTests
    {
        [Fact]
        public void AndThird_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            DependencyPipeline<(RefType, int, DateTime)> sourcePipeline = null!;

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And(otherPipeline));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void AndThird_OtherPipelineIsNull_ExpectArgumentNullException()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((GenerateRefType(), GenerateInteger(), DateTime.Now));
            var sourcePipeline = new DependencyPipeline<(RefType, int, DateTime)>(mockSourceResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And<RefType, int, DateTime, StructType>(null!));
            Assert.Equal("otherPipeline", ex.ParamName);
        }

        [Fact]
        public void AndThird_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((GenerateRefType(), GenerateInteger(), DateTime.Now));
            var sourcePipeline = new DependencyPipeline<(RefType, int, DateTime)>(mockSourceResolver.Object.Resolve);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockSourceResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Fact]
        public void AndThird_ThenResolve_ExpectCallResolveOtherOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((GenerateRefType(), GenerateInteger(), DateTime.Now));
            var sourcePipeline = new DependencyPipeline<(RefType, int, DateTime)>(mockSourceResolver.Object.Resolve);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockOtherResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypeTestSource), MemberType = typeof(TestEntitySource))]
        public void AndThird_ThenResolve_ExpectResolvedtupleValue(
            in RefType? firstValue)
        {
            var secondValue = GenerateDecimal();
            var thirdValue = DateTime.Now.AddYears(5);
            var sourceValue = (firstValue, secondValue, thirdValue);

            var mockSourceResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            var sourcePipeline = new DependencyPipeline<(RefType?, decimal, DateTime)>(mockSourceResolver.Object.Resolve);

            var otherValue = GenerateStructType();
            var mockOtherResolver = MockFuncFactory.CreateMockResolver(otherValue);
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(firstValue, actual.First);
            Assert.Equal(secondValue, actual.Second);
            Assert.Equal(thirdValue, actual.Third);
            Assert.Equal(otherValue, actual.Fourth);
        }
    }
}
