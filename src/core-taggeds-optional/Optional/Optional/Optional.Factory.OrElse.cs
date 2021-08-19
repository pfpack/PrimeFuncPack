#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<T> PresentOrElse<T>(T? value)
            =>
            value is not null
                ? new(value)
                : default;

        public static Optional<T> PresentOrElse<T>(T? value)
            where T : struct
            =>
            value is not null
                ? new(value.GetValueOrDefault())
                : default;
    }
}
