#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> OnPresent(
            Func<T, Unit> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalOnPresent(handler, This);
        }

        public Optional<T> OnPresent(
            Action<T> handler)
        {
            _ = handler ?? throw new ArgumentNullException(nameof(handler));

            return InternalOnPresent(handler.InvokeThenToUnit, This);
        }

        public Task<Optional<T>> OnPresentAsync(
            Func<T, Task<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnPresent(handlerAsync, ThisAsync);
        }

        public Task<Optional<T>> OnPresentAsync(
            Func<T, Task> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnPresent(handlerAsync, ThisAsync);
        }

        public ValueTask<Optional<T>> OnPresentValueAsync(
            Func<T, ValueTask<Unit>> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnPresent(handlerAsync, ThisValueAsync);
        }

        public ValueTask<Optional<T>> OnPresentValueAsync(
            Func<T, ValueTask> handlerAsync)
        {
            _ = handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync));

            return InternalOnPresent(handlerAsync, ThisValueAsync);
        }
    }
}
