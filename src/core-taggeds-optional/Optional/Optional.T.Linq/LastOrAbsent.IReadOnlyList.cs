﻿#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        public static Optional<TSource> LastOrAbsent<TSource>(
            this IReadOnlyList<TSource> source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            return source.InternalLastOrAbsent();
        }

        public static Optional<TSource> LastOrAbsent<TSource>(
            this IReadOnlyList<TSource> source,
            Func<TSource, bool> predicate)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            return source.InternalLastOrAbsent(predicate);
        }
    }
}
