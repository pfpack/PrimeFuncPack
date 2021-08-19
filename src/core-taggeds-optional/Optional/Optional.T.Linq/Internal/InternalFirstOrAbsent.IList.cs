#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IList<TSource> source)
            =>
            source.Count > 0
                ? new(source[0])
                : default;

        public static Optional<TSource> InternalFirstOrAbsent<TSource>(
            this IList<TSource> source,
            Func<TSource, bool> predicate)
        {
            for (var i = 0; i < source.Count; i++)
            {
                var current = source[i];

                if (predicate.Invoke(current))
                {
                    return new(current);
                }
            }

            return default;
        }
    }
}
