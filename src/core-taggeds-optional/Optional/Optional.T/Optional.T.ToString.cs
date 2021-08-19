#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public override string ToString()
            =>
            InternalFold(
                ToStringStrategy<T>.Present,
                ToStringStrategy<T>.Absent);
    }
}
