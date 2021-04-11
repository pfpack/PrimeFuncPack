﻿#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void Second_Implicit_ExpectIsFirstGetsFalse()
        {
            TaggedUnion<StructType, RefType?> taggedUnion = PlusFifteenIdRefType;
            Assert.False(taggedUnion.IsFirst);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Second_Implicit_ExpectIsSecondGetsTrue(
            object? sourceValue)
        {
            TaggedUnion<RefType?, object?> taggedUnion = sourceValue;
            Assert.True(taggedUnion.IsSecond);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Second_Implicit_ExpectIsInitializedGetsTrue(
            object? sourceValue)
        {
            TaggedUnion<StructType, object?> taggedUnion = sourceValue;
            Assert.True(taggedUnion.IsInitialized);
        }
    }
}