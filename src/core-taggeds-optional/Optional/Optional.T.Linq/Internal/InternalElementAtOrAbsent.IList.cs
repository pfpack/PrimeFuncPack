﻿#nullable enable

using System.Collections.Generic;
using static System.Optional;

namespace System.Linq
{
    partial class InternalOptionalLinqExtensions
    {
        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IList<TSource> source,
            int index)
            =>
            InternalIsInRange(index, source.Count)
                ? Present(source[index])
                : default;

        public static Optional<TSource> InternalElementAtOrAbsent<TSource>(
            this IList<TSource> source,
            long index)
            =>
            InternalShortenIndex(index) switch
            {
                int indexShortened when indexShortened == index
                =>
                source.InternalElementAtOrAbsent(indexShortened),

                _ => default
            };
    }
}
