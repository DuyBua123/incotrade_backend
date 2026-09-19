using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncotradeBackend.Infrastructure.Api;
using Microsoft.AspNetCore.Diagnostics;

namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext context,
            Exception exception,
            CancellationToken cancellationToken)
        {
            switch (exception)
            {

                case InputValidationException ex:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    await context.Response.WriteAsJsonAsync(
                        FailureResponse<IDictionary<string, string>>.Failure(
                            "Kiểm tra dữ liệu đầu vào thất bại.",
                            ErrorCodes.INPUT_VALIDATION_ERROR,
                            ex.Errors
                        ), cancellationToken);

                    return true;

                case InvalidCredentialException ex:
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                    await context.Response.WriteAsJsonAsync(
                        FailureResponse<string>.Failure(
                            "Email hoặc mật khẩu không hợp lệ",
                            ErrorCodes.INVALID_CREDENTIAL_ERROR,
                            ex.Error
                        ), cancellationToken);

                    return true;


                case NotFoundException ex:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;

                    await context.Response.WriteAsJsonAsync(
                        FailureResponse<string>.Failure(
                            "Không tìm thấy.",
                            ErrorCodes.NOT_FOUND_ERROR,
                            ex.Message
                        ), cancellationToken);

                    return true;

                default:
                    return false;
            }
        }
    }
}