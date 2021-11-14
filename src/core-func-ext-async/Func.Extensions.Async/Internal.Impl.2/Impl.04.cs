using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncFuncImpl2<T1, T2, T3, T4, TResult> : IAsyncFunc<T1, T2, T3, T4, TResult>
{
    private readonly Func<T1, T2, T3, T4, Task<TResult>> funcAsync;

    internal AsyncFuncImpl2(Func<T1, T2, T3, T4, Task<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken = default)
        =>
        funcAsync.Invoke(arg1, arg2, arg3, arg4);
}
