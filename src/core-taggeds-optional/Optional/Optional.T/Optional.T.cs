#nullable enable

namespace System
{
    public readonly partial struct Optional<T> : IEquatable<Optional<T>>
    {
        private readonly bool hasValue;

        private readonly T value;

        public bool IsPresent
            =>
            hasValue;

        public bool IsAbsent
            =>
            hasValue is false;
    }
}
