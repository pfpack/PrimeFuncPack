#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public Optional(T value)
            =>
            (this.value, hasValue) = (value, true);
    }
}
