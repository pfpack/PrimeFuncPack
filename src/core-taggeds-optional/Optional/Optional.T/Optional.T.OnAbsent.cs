﻿using System.Threading.Tasks;

namespace System;

partial struct Optional<T>
{
    internal Optional<T> OnAbsent(
        Action handler)
        =>
        InnerOnAbsent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Optional<T> OnAbsent<TUnit>(
        Func<TUnit> handler)
        =>
        InnerOnAbsent(
            handler ?? throw new ArgumentNullException(nameof(handler)));

    internal Task<Optional<T>> OnAbsentAsync(
        Func<Task> handlerAsync)
        =>
        InnerOnAbsentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal Task<Optional<T>> OnAbsentAsync<TUnit>(
        Func<Task<TUnit>> handlerAsync)
        =>
        InnerOnAbsentAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<Optional<T>> OnAbsentValueAsync(
        Func<ValueTask> handlerAsync)
        =>
        InnerOnAbsentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));

    internal ValueTask<Optional<T>> OnAbsentValueAsync<TUnit>(
        Func<ValueTask<TUnit>> handlerAsync)
        =>
        InnerOnAbsentValueAsync(
            handlerAsync ?? throw new ArgumentNullException(nameof(handlerAsync)));
}
