using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncotradeBackend.Infrastructure.Api
{
    public record SuccessResponse<T> (
        string Message,
        T? Data,
        DateTime Timestamp
    )
    {
        public static SuccessResponse<T> Success(string message, T? data)
        {
            return new SuccessResponse<T>(
                message,
                data,
                DateTime.UtcNow
            );
        }

        public static SuccessResponse<T> SuccessData(T? data)
        {
            return Success("Success", data);
        }

        public static SuccessResponse<object?> SuccessMessage(string message)
        {
            return new SuccessResponse<object?>(
                message,
                null,
                DateTime.UtcNow
            );
        }
    }
}