using FluentValidation;
using IncotradeBackend.Presentation.Booking.Request;

namespace IncotradeBackend.Presentation.Booking.Validator
{
    public class CreateBookingRequestValidator :
        AbstractValidator<CreateBookingRequest>
    {
        public CreateBookingRequestValidator()
        {
            RuleFor(x => x.ServiceId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã dịch vụ không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã dịch vụ không hợp lệ.");

            RuleFor(x => x.StaffScheduleId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã lịch làm việc không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã lịch làm việc không hợp lệ.");

            RuleFor(x => x.StartTime)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Giờ bắt đầu không được để trống.")
                .Must(BeTimeOnly).WithMessage("Giờ bắt đầu không hợp lệ.");

            RuleFor(x => x.CustomerNote)
                .MaximumLength(255)
                .WithMessage("Ghi chú của khách hàng không được vượt quá 255 ký tự.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }

        private static bool BeTimeOnly(string value)
        {
            return TimeOnly.TryParse(value, out _);
        }

    }
}
