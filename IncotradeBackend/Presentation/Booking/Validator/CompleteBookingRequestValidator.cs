using FluentValidation;
using IncotradeBackend.Presentation.Booking.Request;

namespace IncotradeBackend.Presentation.Booking.Validator
{
    public class CompleteBookingRequestValidator :
        AbstractValidator<CompleteBookingRequest>
    {
        public CompleteBookingRequestValidator()
        {
            RuleFor(x => x.BookingId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mã lịch hẹn không được để trống.")
                .Must(BePositiveInteger).WithMessage("Mã lịch hẹn không hợp lệ.");
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }
    }
}
