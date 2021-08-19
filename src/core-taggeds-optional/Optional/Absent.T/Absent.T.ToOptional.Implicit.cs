#nullable enable

namespace System
{
    partial struct Absent<T>
    {
        public static implicit operator Optional<T>(Absent<T> absent) => absent switch
        {
            _ => default
        };
    }
}
