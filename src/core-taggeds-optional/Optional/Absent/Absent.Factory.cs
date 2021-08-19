#nullable enable

using System.Runtime.CompilerServices;

namespace System
{
    partial class Absent
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Absent<T> Of<T>()
            =>
            default;
    }
}
