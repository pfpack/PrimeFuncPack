#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial struct Optional<T>
    {
        public override int GetHashCode()
            =>
            hasValue ? PresentHashCode() : AbsentHashCode();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int PresentHashCode()
            =>
            value is not null
                ? HashCode.Combine(EqualityContract, true, EqualityComparer.GetHashCode(value))
                : HashCode.Combine(EqualityContract, true);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int AbsentHashCode()
            =>
            HashCode.Combine(EqualityContract);
    }
}
