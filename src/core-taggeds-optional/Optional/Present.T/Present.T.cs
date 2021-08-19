#nullable enable

namespace System
{
    public readonly partial struct Present<T> : IEquatable<Present<T>>
    {
        private readonly T value;
    }
}
