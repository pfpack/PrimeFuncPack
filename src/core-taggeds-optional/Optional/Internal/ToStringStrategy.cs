#nullable enable

using static System.FormattableString;

namespace System
{
    internal static class ToStringStrategy<T>
    {
        public static string Present(T value)
            =>
            Invariant($"A present value of type {typeof(T).Name}: {{ Value: {value} }}.");

        public static string Absent()
            =>
            Invariant($"The absent value of type {typeof(T).Name}: {{ Value: () }}.");
    }
}
