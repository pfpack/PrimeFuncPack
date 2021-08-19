#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<T> PresentOrThrow<T>(T? value)
            =>
            value is not null
                ? new(value)
                : throw CreateExpectedSpecifiedException(nameof(value));

        public static Optional<T> PresentOrThrow<T>(T? value)
            where T : struct
            =>
            value is not null
                ? new(value.GetValueOrDefault())
                : throw CreateExpectedSpecifiedException(nameof(value));
    }
}
