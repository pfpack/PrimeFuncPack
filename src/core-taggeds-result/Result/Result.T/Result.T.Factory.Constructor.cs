#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result(TSuccess success)
            =>
            (this.success, failure, isSuccess) = (success, default, true);

        public Result(TFailure failure)
            =>
            (this.failure, success, isSuccess) = (failure, default!, false);
    }
}
