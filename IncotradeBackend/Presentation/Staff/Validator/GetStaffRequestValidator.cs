using FluentValidation;
using IncotradeBackend.Presentation.Staff.Request;

namespace IncotradeBackend.Presentation.Staff.Validator
{
    public class GetStaffRequestValidator : AbstractValidator<GetStaffRequest>
    {
        public GetStaffRequestValidator()
        {
            RuleFor(x => x.StaffId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã nhân viên không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã nhân viên không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }
    }
}
