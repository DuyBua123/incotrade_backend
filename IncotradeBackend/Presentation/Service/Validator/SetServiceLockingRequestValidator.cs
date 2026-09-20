using FluentValidation;
using IncotradeBackend.Presentation.Service.Request;

namespace IncotradeBackend.Presentation.Service.Validator
{
    public class SetServiceLockingRequestValidator : AbstractValidator<SetServiceLockingRequest>
    {
        public SetServiceLockingRequestValidator()
        {
            RuleFor(x => x.ServiceId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã dịch vụ không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã dịch vụ không hợp lệ.");

            RuleFor(x => x.IsLocked)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Trạng thái khóa dịch vụ không được để trống.")
                .Must(BeBoolean).WithMessage("Trạng thái khóa dịch vụ không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }

        private static bool BeBoolean(string value)
        {
            return bool.TryParse(value, out _);
        }
    }
}
