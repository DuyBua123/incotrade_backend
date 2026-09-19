using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncotradeBackend.Infrastructure.Api
{
    public record FailureResponse<T>(
        string Message,
        string Code,
        T? Errors,
        DateTime Timestamp
    )
    {
        public static FailureResponse<T> Failure(string message, string code, T? errors)
        {
            return new FailureResponse<T>(
                message,
                code,
                errors,
                DateTime.UtcNow
            );
        }

        public static FailureResponse<T> FailureData(string code, T? errors)
        {
            return Failure("Failure", code, errors);
        }

        public static FailureResponse<object?> FailureMessage(string message, string code)
        {
            return new FailureResponse<object?>(
                message,
                code,
                null,
                DateTime.UtcNow
            );
        }

    }
}