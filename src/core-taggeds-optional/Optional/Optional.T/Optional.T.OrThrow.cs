﻿#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public T OrThrow()
            =>
            InternalOrThrow(CreateExpectedPresentException);

        public T OrThrow(Func<Exception> exceptionFactory)
            =>
            InternalOrThrow(exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory)));
    }
}
