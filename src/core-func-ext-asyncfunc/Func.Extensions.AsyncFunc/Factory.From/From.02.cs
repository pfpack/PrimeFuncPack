#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<T1, T2, TResult> From<T1, T2, TResult>(
        Func<T1, T2, CancellationToken, Task<TResult>> funcAsync)
        =>
        new AsyncFuncImpl<T1, T2, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));

    public static IAsyncFunc<T1, T2, TResult> From<T1, T2, TResult>(
        Func<T1, T2, Task<TResult>> funcAsync)
        =>
        new AsyncFuncImpl2<T1, T2, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));

    public static IAsyncFunc<T1, T2, TResult> From<T1, T2, TResult>(
        Func<T1, T2, TResult> func)
        =>
        new AsyncFuncImpl3<T1, T2, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}