#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public static implicit operator Optional<T>(Present<T> present)
            =>
            new(present.value);
    }
}
