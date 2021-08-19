#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<Unit> True()
            =>
            new(default);

        public static Optional<Unit> False()
            =>
            default;
    }
}
