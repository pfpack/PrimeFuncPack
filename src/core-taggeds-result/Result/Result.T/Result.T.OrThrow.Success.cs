﻿namespace System;

partial struct Result<TSuccess, TFailure>
{
    public TSuccess SuccessOrThrow()
        =>
        InnerSuccessOrThrow(CreateNotSuccessException);

    public TSuccess SuccessOrThrow(Func<Exception> exceptionFactory)
    {
        _ = exceptionFactory ?? throw new ArgumentNullException(nameof(exceptionFactory));

        return InnerSuccessOrThrow(exceptionFactory);
    }
}
