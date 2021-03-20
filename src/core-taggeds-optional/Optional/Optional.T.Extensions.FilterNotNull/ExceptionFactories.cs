﻿#nullable enable

namespace System
{
    partial class FilterNotNullOptionalExtensions
    {
        private static InvalidOperationException CreateExpectedNotNullOrAbsentException()
            =>
            new("The optional is expected to have a not null value or to be absent.");

        private static InvalidOperationException CreateUnexpectedNullException_MustNeverBeInvoked()
            =>
            new("The optional has unexpected null value.");
    }
}
