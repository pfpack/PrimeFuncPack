﻿#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class OptionalLinqExtensions
    {
        public static Optional<TSource> FirstOrAbsent<TSource>(
            this IEnumerable<TSource> source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            return source switch
            {
                IReadOnlyList<TSource> list => list
                .InternalFirstOrAbsent(),

                IList<TSource> list => list
                .InternalFirstOrAbsent(),

                _ => source
                .InternalFirstOrAbsent()
            };
        }

        public static Optional<TSource> FirstOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = predicate ?? throw new ArgumentNullException(nameof(predicate));

            return source switch
            {
                IReadOnlyList<TSource> list => list
                .InternalFirstOrAbsent(predicate),

                IList<TSource> list => list
                .InternalFirstOrAbsent(predicate),

                _ => source
                .InternalFirstOrAbsent(predicate)
            };
        }
    }
}
