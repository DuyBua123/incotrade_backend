using FluentValidation;
using IncotradeBackend.Presentation.Staff.Request;

namespace IncotradeBackend.Presentation.Staff.Validator
{
    public class CreateStaffScheduleRequestValidator :
        AbstractValidator<CreateStaffScheduleRequest>
    {
        public CreateStaffScheduleRequestValidator()
        {
            RuleFor(x => x.StaffId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã nhân viên không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã nhân viên không hợp lệ.");

            RuleFor(x => x.WorkDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Ngày làm việc không được để trống.")
                .Must(BeDateOnly).WithMessage("Ngày làm việc không hợp lệ.")
                .Must(NotBePastDate).WithMessage("Ngày làm việc không được ở quá khứ.");

            RuleFor(x => x.StartTime)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Giờ bắt đầu không được để trống.")
                .Must(BeTimeOnly).WithMessage("Giờ bắt đầu không hợp lệ.");

            RuleFor(x => x.EndTime)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Giờ kết thúc không được để trống.")
                .Must(BeTimeOnly).WithMessage("Giờ kết thúc không hợp lệ.")
                .Must((request, endTime) => BeAfterStartTime(
                    request.StartTime,
                    endTime))
                .WithMessage("Giờ kết thúc phải sau giờ bắt đầu.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }

        private static bool BeDateOnly(string value)
        {
            return DateOnly.TryParse(value, out _);
        }

        private static bool NotBePastDate(string value)
        {
            return DateOnly.TryParse(value, out DateOnly date)
                && date >= DateOnly.FromDateTime(DateTime.Today);
        }

        private static bool BeTimeOnly(string value)
        {
            return TimeOnly.TryParse(value, out _);
        }

        private static bool BeAfterStartTime(string startTime, string endTime)
        {
            return TimeOnly.TryParse(startTime, out TimeOnly start)
                && TimeOnly.TryParse(endTime, out TimeOnly end)
                && end > start;
        }
    }
}
