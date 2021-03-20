﻿#nullable enable

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        private static InvalidOperationException CreateMoreThanOneElementException()
            =>
            new("The collection contains more than one element.");

        private static InvalidOperationException CreateMoreThanOneMatchException()
            =>
            new("The collection contains more than one element matching to the predicate.");
    }
}
