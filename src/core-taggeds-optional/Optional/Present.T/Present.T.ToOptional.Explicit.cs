#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public Optional<T> ToOptional()
            =>
            new(value);
    }
}
