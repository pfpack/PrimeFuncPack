﻿#nullable enable

using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    internal static class TestDataSource
    {
        public static IEnumerable<object?[]> ObjectNullableTestSource
            =>
            new object?[]
            {
                null,
                new object(),
                MinusFifteen,
                PlusFifteenIdRefType,
                SomeTextStructType
            }
            .ToNullableTestSource();

        private static IEnumerable<object?[]> ToNullableTestSource(this IEnumerable<object?> source)
            =>
            source.Select(v => new[] { v });
    }
}
