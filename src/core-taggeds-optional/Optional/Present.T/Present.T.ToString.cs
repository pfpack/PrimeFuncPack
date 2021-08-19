#nullable enable

namespace System
{
    partial struct Present<T>
    {
        public override string ToString()
            =>
            ToStringStrategy<T>.Present(value);
    }
}
