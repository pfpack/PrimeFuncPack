#nullable enable

namespace System
{
    partial struct TaggedUnion<TFirst, TSecond>
    {
        public TaggedUnion(TFirst first)
            =>
            (this.first, second, tag) = (first, default!, Tag.First);

        public TaggedUnion(TSecond second)
            =>
            (this.second, first, tag) = (second, default!, Tag.Second);
    }
}
