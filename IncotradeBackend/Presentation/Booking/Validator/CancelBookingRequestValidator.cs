using FluentValidation;
using IncotradeBackend.Presentation.Booking.Request;

namespace IncotradeBackend.Presentation.Booking.Validator
{
    public class CancelBookingRequestValidator :
        AbstractValidator<CancelBookingRequest>
    {
        public CancelBookingRequestValidator()
        {
            RuleFor(x => x.BookingId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã lịch hẹn không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã lịch hẹn không hợp lệ.");

            RuleFor(x => x.CancellationReason)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Lý do hủy lịch hẹn không được để trống.")
                .MaximumLength(255).WithMessage("Lý do hủy lịch hẹn không được vượt quá 255 ký tự.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }
    }
}
