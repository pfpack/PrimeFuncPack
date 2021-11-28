﻿using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TResult InnerFoldThis<TResult>(
            Func<Optional<T>, TResult> map,
            Func<TResult> otherFactory)
            =>
            hasValue
                ? map.Invoke(this)
                : otherFactory.Invoke();
    }
}
