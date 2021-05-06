#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    public interface IAsyncValueFunc<in T1, in T2, in T3, in T4, in T5, TResult>
    {
        ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken = default);
    }
}