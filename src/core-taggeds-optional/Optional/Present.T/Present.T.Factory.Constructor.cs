#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public Present(T value)
            =>
            this.value = value;
    }
}
