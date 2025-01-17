﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Linq;

partial class OptionalLinqExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<TSource> InnerLastOrAbsent<TSource>(
        this IEnumerable<TSource> source)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerLastOrAbsent_IReadOnlyList(),

            IList<TSource> list
            =>
            list.InnerLastOrAbsent_IList(),

            _ =>
            source.InnerLastOrAbsent_IEnumerable()
        };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Optional<TSource> InnerLastOrAbsent<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        =>
        source switch
        {
            IReadOnlyList<TSource> list
            =>
            list.InnerLastOrAbsent_IReadOnlyList(predicate),

            IList<TSource> list
            =>
            list.InnerLastOrAbsent_IList(predicate),

            _ =>
            source.InnerLastOrAbsent_IEnumerable(predicate)
        };
}
