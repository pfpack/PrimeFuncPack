﻿#nullable enable

using System;

namespace PrimeFuncPack.Core
{
    partial struct SuccessBuilder<TSuccess>
    {
        public override string ToString()
            =>
            success.ToStringOrEmpty();
    }
}
