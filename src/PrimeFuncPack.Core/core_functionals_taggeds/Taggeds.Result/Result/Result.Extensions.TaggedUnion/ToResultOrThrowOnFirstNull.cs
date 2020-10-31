﻿#nullable enable

namespace System
{
    partial class TaggedUnionResultExtensions
    {
        public static Result<TSuccess, TFailure> ToResultOrThrowOnFirstNull<TSuccess, TFailure>(
            this TaggedUnion<TSuccess, TFailure> union)
            where TSuccess : notnull
            where TFailure : struct
            =>
            union.Fold(
                value => value switch
                {
                    not null => Result<TSuccess, TFailure>.Success(value),
                    _ => throw new InvalidOperationException("The tagged union first is expected to be not null."),
                },
                Result<TSuccess, TFailure>.Failure);
    }
}
