#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public bool Equals(Optional<T> other)
        {
            if (hasValue != other.hasValue)
            {
                return false;
            }

            if (hasValue)
            {
                return EqualityComparer.Equals(value, other.value);
            }
            else
            {
                return true;
            }
        }
    }
}
