﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System;

partial struct Optional<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool InnerContains(T value, IEqualityComparer<T> comparer)
        =>
        hasValue && comparer.Equals(this.value, value);
}
