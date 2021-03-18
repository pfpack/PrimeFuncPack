﻿#nullable enable

using static System.Optional;

namespace System
{
    partial class OptionalResultExtensions
    {
        public static Optional<TSuccess> ToOptional<TSuccess>(this Result<TSuccess, Unit> result)
            =>
            result.Fold(Present<TSuccess>, Absent<TSuccess>);
    }
}
