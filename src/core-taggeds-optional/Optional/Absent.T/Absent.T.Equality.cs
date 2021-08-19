#nullable enable

namespace System
{
    partial struct Absent<T>
    {
        public static bool Equals(Absent<T> left, Absent<T> right) => (left, right) switch
        {
            _ => true
        };

        public static bool operator ==(Absent<T> left, Absent<T> right) => (left, right) switch
        {
            _ => true
        };

        public static bool operator !=(Absent<T> left, Absent<T> right) => (left, right) switch
        {
            _ => false
        };

        public bool Equals(Absent<T> other)
            =>
            true;

        public override bool Equals(object? obj)
            =>
            obj is Absent<T>;

        public override int GetHashCode()
            =>
            HashCode.Combine(typeof(Absent<T>));
    }
}
