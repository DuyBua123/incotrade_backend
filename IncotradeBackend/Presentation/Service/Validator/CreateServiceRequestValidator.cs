using FluentValidation;
using IncotradeBackend.Presentation.Service.Request;

namespace IncotradeBackend.Presentation.Service.Validator
{
    public class CreateServiceRequestValidator : AbstractValidator<CreateServiceRequest>
    {
        public CreateServiceRequestValidator()
        {
            RuleFor(x => x.ServiceName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Tên dịch vụ không được để trống.");

            RuleFor(x => x.DurationMinutes)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Thời lượng dịch vụ không được để trống.")
                .Must(BePositiveInteger).WithMessage("Thời lượng dịch vụ không hợp lệ.");

            RuleFor(x => x.Price)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Giá dịch vụ không được để trống.")
                .Must(BePositiveLong).WithMessage("Giá dịch vụ không hợp lệ.");

            RuleFor(x => x.IsLock)
                .Cascade(CascadeMode.Stop)
                .Must(BeBoolean).When(x => !string.IsNullOrWhiteSpace(x.IsLock))
                .WithMessage("Trạng thái khóa dịch vụ không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }

        private static bool BePositiveLong(string value)
        {
            return long.TryParse(value, out long number) && number > 0;
        }

        private static bool BeBoolean(string? value)
        {
            return bool.TryParse(value, out _);
        }
    }
}
