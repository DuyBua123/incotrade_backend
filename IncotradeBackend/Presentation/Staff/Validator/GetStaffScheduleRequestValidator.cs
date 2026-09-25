using FluentValidation;
using IncotradeBackend.Presentation.Staff.Request;

namespace IncotradeBackend.Presentation.Staff.Validator
{
    public class GetStaffScheduleRequestValidator :
        AbstractValidator<GetStaffScheduleRequest>
    {
        public GetStaffScheduleRequestValidator()
        {
            RuleFor(x => x.StaffScheduleId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã lịch làm việc không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã lịch làm việc không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }
    }
}
