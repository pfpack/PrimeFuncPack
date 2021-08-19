#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IList<TSource> source)
            =>
            source.Count > 0
                ? new(source[^1])
                : default;

        public static Optional<TSource> InternalLastOrAbsent<TSource>(
            this IList<TSource> source,
            Func<TSource, bool> predicate)
        {
            for (var i = source.Count - 1; i >= 0; i--)
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
