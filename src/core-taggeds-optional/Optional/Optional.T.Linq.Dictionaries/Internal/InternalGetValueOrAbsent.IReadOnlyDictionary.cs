﻿#nullable enable

using System.Collections.Generic;
using static System.Optional;

namespace System.Linq
{
    partial class InternalOptionalLinqDictionariesExtensions
    {
        public static Optional<TValue> InternalGetValueOrAbsent<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary,
            TKey key)
            =>
            dictionary.TryGetValue(key, out var value)
                ? Present(value)
                : default;
    }
}
