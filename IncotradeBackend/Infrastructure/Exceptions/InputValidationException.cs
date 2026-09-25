
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IncotradeBackend.Infrastructure.Exceptions
{
    public class InputValidationException : Exception
    {
        public IDictionary<string, string> Errors { get; }

        public InputValidationException(ModelStateDictionary modelState)
            : base("Kiểm tra dữ liệu đầu vào thất bại.")
        {
            Errors = modelState
                .Where(x => x.Value is { Errors.Count: > 0 })
                .ToDictionary(
                    x => x.Key,
                    x => x.Value!.Errors
                        .Select(e => string.IsNullOrWhiteSpace(e.ErrorMessage)
                            ? e.Exception?.Message ?? "Giá trị không hợp lệ."
                            : e.ErrorMessage)
                        .First());
        }

    }
}