﻿#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // Recover

        public Result<TOtherSuccess, TOtherFailure> Recover<TOtherSuccess, TOtherFailure>(
            Func<TFailure, Result<TOtherSuccess, TOtherFailure>> otherFactory,
            Func<TSuccess, TOtherSuccess> mapSuccess)
            where TOtherSuccess : notnull
            where TOtherFailure : struct
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return Fold(success => mapSuccess.Invoke(success), otherFactory);
        }

        public Result<TSuccess, TOtherFailure> Recover<TOtherFailure>(
            Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory)
            where TOtherFailure : struct
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            return Fold(success => success, otherFactory);
        }

        public Result<TSuccess, TFailure> Recover(
            Func<TFailure, Result<TSuccess, TFailure>> otherFactory)
        {
            _ = otherFactory ?? throw new ArgumentNullException(nameof(otherFactory));

            var @this = this;

            return Fold(_ => @this, otherFactory);
        }

        // Recover Async / Task

        public Task<Result<TOtherSuccess, TOtherFailure>> RecoverAsync<TOtherSuccess, TOtherFailure>(
            Func<TFailure, Task<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
            Func<TSuccess, TOtherSuccess> mapSuccess)
            where TOtherSuccess : notnull
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return FoldAsync(
                success => Task.FromResult<Result<TOtherSuccess, TOtherFailure>>(mapSuccess.Invoke(success)),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TOtherFailure>> RecoverAsync<TOtherFailure>(
            Func<TFailure, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return FoldAsync(
                success => Task.FromResult<Result<TSuccess, TOtherFailure>>(success),
                otherFactoryAsync);
        }

        public Task<Result<TSuccess, TFailure>> RecoverAsync(
            Func<TFailure, Task<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            var @this = this;

            return FoldAsync(_ => Task.FromResult(@this), otherFactoryAsync);
        }

        // Recover Async / ValueTask

        public ValueTask<Result<TOtherSuccess, TOtherFailure>> RecoverValueAsync<TOtherSuccess, TOtherFailure>(
            Func<TFailure, ValueTask<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
            Func<TSuccess, TOtherSuccess> mapSuccess)
            where TOtherSuccess : notnull
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));
            _ = mapSuccess ?? throw new ArgumentNullException(nameof(mapSuccess));

            return FoldValueAsync(
                success => ValueTask.FromResult<Result<TOtherSuccess, TOtherFailure>>(mapSuccess.Invoke(success)),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TOtherFailure>> RecoverValueAsync<TOtherFailure>(
            Func<TFailure, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
            where TOtherFailure : struct
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            return FoldValueAsync(
                success => ValueTask.FromResult<Result<TSuccess, TOtherFailure>>(success),
                otherFactoryAsync);
        }

        public ValueTask<Result<TSuccess, TFailure>> RecoverValueAsync(
            Func<TFailure, ValueTask<Result<TSuccess, TFailure>>> otherFactoryAsync)
        {
            _ = otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync));

            var @this = this;

            return FoldValueAsync(_ => ValueTask.FromResult(@this), otherFactoryAsync);
        }
    }
}
