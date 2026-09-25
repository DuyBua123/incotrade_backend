using FluentValidation;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Presentation.Booking.Request;

namespace IncotradeBackend.Presentation.Booking.Validator
{
    public class GetMyBookingsRequestValidator :
        AbstractValidator<GetMyBookingsRequest>
    {
        public GetMyBookingsRequestValidator()
        {
            RuleFor(x => x.Page)
                .Cascade(CascadeMode.Stop)
                .Must(BePositiveInteger).WithMessage("Trang không hợp lệ.");

            RuleFor(x => x.Size)
                .Cascade(CascadeMode.Stop)
                .Must(BePositiveInteger).WithMessage("Kích thước trang không hợp lệ.");

            RuleFor(x => x.ServedDate)
                .Must(BeDateOnly).WithMessage("Ngày phục vụ không hợp lệ.")
                .When(x => !string.IsNullOrWhiteSpace(x.ServedDate));

            RuleFor(x => x.Status)
                .Must(BeBookingStatus).WithMessage("Trạng thái lịch hẹn không hợp lệ.")
                .When(x => !string.IsNullOrWhiteSpace(x.Status));
        }

        private static bool BePositiveInteger(string value)
        {
            return int.TryParse(value, out int number) && number > 0;
        }

        private static bool BeDateOnly(string? value)
        {
            return DateOnly.TryParse(value, out _);
        }

        private static bool BeBookingStatus(string? value)
        {
            return Enum.TryParse<BookingStatus>(value, true, out _);
        }
    }
}
