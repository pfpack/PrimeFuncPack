#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static implicit operator Optional<T>(T value)
            =>
            new(value);
    }
}
