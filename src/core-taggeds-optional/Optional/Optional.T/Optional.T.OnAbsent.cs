﻿#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> OnAbsent(
            Func<Unit> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InnerOnAbsent(handler, InnerThis);
        }

        public Optional<T> OnAbsent(
            Action handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InnerOnAbsent(handler.InvokeThenToUnit, InnerThis);
        }

        public Task<Optional<T>> OnAbsentAsync(
            Func<Task<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnAbsent(handlerAsync, InnerThisAsync);
        }

        public Task<Optional<T>> OnAbsentAsync(
            Func<Task> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnAbsent(handlerAsync, InnerThisAsync);
        }

        public ValueTask<Optional<T>> OnAbsentValueAsync(
            Func<ValueTask<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnAbsent(handlerAsync, InnerThisValueAsync);
        }

        public ValueTask<Optional<T>> OnAbsentValueAsync(
            Func<ValueTask> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InnerOnAbsent(handlerAsync, InnerThisValueAsync);
        }
    }
}
