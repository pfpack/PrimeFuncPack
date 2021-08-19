#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public static Present<T> Of(T value)
            =>
            new(value);
    }
}
