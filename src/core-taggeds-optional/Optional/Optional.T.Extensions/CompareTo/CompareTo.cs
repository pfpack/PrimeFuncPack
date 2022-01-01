﻿using static System.FormattableString;

namespace System;

partial class OptionalExtensions
{
    // TODO: Add the tests and open the method
    internal static int CompareTo<T>(this Optional<T> optional, Optional<T> other)
        where T : IComparable<T>
        =>
        optional.InternalCompareTo(other);

    // TODO: Add the tests and open the method
    internal static int CompareTo<T>(this Optional<T> optional, object? obj)
        where T : IComparable<T>
        =>
        obj switch
        {
            null => 1,

            Optional<T> other => optional.InternalCompareTo(other),

            _ => throw new ArgumentException(Invariant($"The object is not Optional[{typeof(T)}]"), nameof(obj))
        };
}
