﻿#nullable enable

namespace System
{
    public static class NullPredicates
    {
        public static bool IsNotNull<T>(in T value)
            =>
            value is object;

        public static bool IsNotNull<T>(T value)
            =>
            IsNotNull(in value);

        public static bool IsNull<T>(in T value)
            =>
            value is null;

        public static bool IsNull<T>(T value)
            =>
            IsNull(in value);
    }
}
