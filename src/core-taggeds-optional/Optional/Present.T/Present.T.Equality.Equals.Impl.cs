#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public bool Equals(Present<T> other)
            =>
            EqualityComparer.Equals(value, other.value);
    }
}
