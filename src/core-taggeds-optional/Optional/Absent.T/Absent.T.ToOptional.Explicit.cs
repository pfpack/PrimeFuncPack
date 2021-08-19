#nullable enable

namespace System
{
    partial struct Absent<T>
    {
        public Optional<T> ToOptional()
            =>
            default;
    }
}
