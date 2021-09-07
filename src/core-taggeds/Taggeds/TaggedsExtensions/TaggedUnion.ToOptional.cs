﻿#nullable enable

namespace System
{
    partial class TaggedsExtensions
    {
        public static Optional<T> ToOptional<T>(this TaggedUnion<T, Unit> union)
            =>
            union.Fold(Optional<T>.Present, static _ => default);
    }
}
