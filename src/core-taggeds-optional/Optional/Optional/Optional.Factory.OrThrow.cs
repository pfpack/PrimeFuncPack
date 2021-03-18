﻿#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<T> PresentOrThrow<T>(T? value)
            =>
            value is not null
                ? Optional<T>.Present(value)
                : throw CreateExpectedNotNullException(nameof(value));

        public static Optional<T> PresentOrThrow<T>(T? value)
            where T : struct
            =>
            value is not null
                ? Optional<T>.Present(value.GetValueOrDefault())
                : throw CreateExpectedNotNullException(nameof(value));
    }
}
