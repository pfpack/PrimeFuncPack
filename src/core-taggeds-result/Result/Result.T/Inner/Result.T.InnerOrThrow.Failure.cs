﻿using System.Runtime.CompilerServices;

namespace System;

partial struct Result<TSuccess, TFailure>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TFailure InnerFailureOrThrow(Func<Exception> exceptionFactory)
        =>
        isSuccess is false
            ? failure
            : throw exceptionFactory.Invoke();
}