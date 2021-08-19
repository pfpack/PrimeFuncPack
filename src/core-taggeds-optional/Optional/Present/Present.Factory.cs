#nullable enable

namespace System
{
    partial class Present
    {
        public static Present<T> Of<T>(T value)
            =>
            new(value);
    }
}
