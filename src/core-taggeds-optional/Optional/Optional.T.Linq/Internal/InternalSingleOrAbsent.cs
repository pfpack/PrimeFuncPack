#nullable enable

using System.Collections.Generic;

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            Func<Exception> moreThanOneElementExceptionFactory)
        {
            using var enumerator = source.GetEnumerator();

            if (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                if (enumerator.MoveNext())
                {
                    throw moreThanOneElementExceptionFactory.Invoke();
                }

                return new(current);
            }

            return default;
        }

        public static Optional<TSource> InternalSingleOrAbsent<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate,
            Func<Exception> moreThanOneMatchExceptionFactory)
        {
            using var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;

                if (predicate.Invoke(current))
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate.Invoke(enumerator.Current))
                        {
                            throw moreThanOneMatchExceptionFactory.Invoke();
                        }
                    }

                    return new(current);
                }
            }

            return default;
        }
    }
}
