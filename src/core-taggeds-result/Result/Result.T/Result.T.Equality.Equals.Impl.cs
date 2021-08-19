#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public bool Equals(Result<TSuccess, TFailure> other)
        {
            if (isSuccess != other.isSuccess)
            {
                return false;
            }

            if (isSuccess)
            {
                return SuccessComparer.Equals(success, other.success);
            }
            else
            {
                return FailureComparer.Equals(failure, other.failure);
            }
        }
    }
}
