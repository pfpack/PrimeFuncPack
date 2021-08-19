#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public override int GetHashCode()
            =>
            value is not null
                ? HashCode.Combine(EqualityContract, EqualityComparer.GetHashCode(value))
                : HashCode.Combine(EqualityContract);
    }
}
