﻿#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional<TResult> Map<TResult>(in Func<T, TResult> map)
            =>
            IsPresent switch
            {
                true => Optional<TResult>.Present(map.Invoke(Value)),
                _ => default
            };
    }
}