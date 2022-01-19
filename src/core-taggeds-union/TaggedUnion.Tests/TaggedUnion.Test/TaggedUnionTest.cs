﻿using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

public sealed partial class TaggedUnionTest
{
    private const string First = "First";

    private const string Second = "Second";

    private static void AssertContains(
        string expectedSubstring,
        string? actual,
        StringComparison comparison = StringComparison.Ordinal)
    {
        Assert.NotNull(actual);
        Assert.True(actual!.Contains(expectedSubstring, comparison));
    }
}
