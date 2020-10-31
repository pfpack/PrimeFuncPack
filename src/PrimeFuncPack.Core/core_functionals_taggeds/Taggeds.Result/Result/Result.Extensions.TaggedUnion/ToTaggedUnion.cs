﻿#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        public static TaggedUnion<TSuccess, TFailure> ToTaggedUnion<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
            where TSuccess : notnull
            where TFailure : struct
            =>
            result.Fold(TaggedUnion<TSuccess, TFailure>.First, TaggedUnion<TSuccess, TFailure>.Second);
    }
}
