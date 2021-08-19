#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public static bool Equals(Present<T> left, Present<T> right)
            =>
            left.Equals(right);

        public static bool operator ==(Present<T> left, Present<T> right)
            =>
            left.Equals(right);

        public static bool operator !=(Present<T> left, Present<T> right)
            =>
            left.Equals(right) is false;

        public override bool Equals(object? obj)
            =>
            obj is Present<T> other &&
            Equals(other);
    }
}
