﻿#nullable enable

namespace System
{
    partial class OptionalResultExtensions
    {
        public static Result<T, Unit> ToResultOrFailureOnNull<T>(this Optional<T> optional) where T : notnull
            =>
            optional
            .FilterNotNull()
            .Fold(Result.Present<T>, Result.Absent<T>);
    }
}
