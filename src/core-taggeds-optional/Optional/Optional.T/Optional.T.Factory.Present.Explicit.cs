#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static Optional<T> Present(T value)
            =>
            new(value);
    }
}
