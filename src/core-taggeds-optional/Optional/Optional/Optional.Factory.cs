#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<T> Present<T>(T value)
            =>
            new(value);

        public static Optional<T> Absent<T>()
            =>
            default;

        public static Optional<T> Absent<T>(Unit unit) => unit switch
        {
            _ =>
            default
        };
    }
}
