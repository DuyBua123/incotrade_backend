using FluentValidation;
using IncotradeBackend.Presentation.Staff.Request;

namespace IncotradeBackend.Presentation.Staff.Validator
{
    public class UpdateStaffRequestValidator : AbstractValidator<UpdateStaffRequest>
    {
        public UpdateStaffRequestValidator()
        {
            RuleFor(x => x.StaffId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã nhân viên không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã nhân viên không hợp lệ.");

            RuleFor(x => x.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Họ tên nhân viên không được để trống.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email nhân viên không được để trống.")
                .EmailAddress().WithMessage("Email nhân viên không hợp lệ.");

            RuleFor(x => x.IsLock)
                .Cascade(CascadeMode.Stop)
                .Must(BeBoolean).When(x => !string.IsNullOrWhiteSpace(x.IsLock))
                .WithMessage("Trạng thái khóa nhân viên không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }

        private static bool BeBoolean(string? value)
        {
            return bool.TryParse(value, out _);
        }
    }
}
