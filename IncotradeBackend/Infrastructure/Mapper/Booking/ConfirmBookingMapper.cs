using IncotradeBackend.Application.Booking.ConfirmBooking;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Booking
{
    public static class ConfirmBookingMapper
    {
        public static ConfirmBookingCommand ToCommand(
            ConfirmBookingRequest request)
        {
            return new ConfirmBookingCommand
            {
                BookingId = int.Parse(request.BookingId)
            };
        }

        public static ConfirmBookingResult ToResult(
            Database.Model.Booking booking)
        {
            return new ConfirmBookingResult
            {
                Id = booking.Id,
                BookingCode = booking.BookingCode,
                CustomerId = booking.CustomerId,
                ServiceId = booking.ServiceId,
                StaffId = booking.StaffId,
                ServedDate = booking.ServedDate,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                Status = booking.Status,
                CustomerNote = booking.CustomerNote,
                CancellationReason = booking.CancellationReason,
                CreatedAt = booking.CreatedAt,
                UpdatedAt = booking.UpdatedAt
            };
        }

        public static ConfirmBookingResponse ToResponse(
            ConfirmBookingResult result)
        {
            return new ConfirmBookingResponse
            {
                Id = result.Id,
                BookingCode = result.BookingCode,
                CustomerId = result.CustomerId,
                ServiceId = result.ServiceId,
                StaffId = result.StaffId,
                ServedDate = result.ServedDate,
                StartTime = result.StartTime,
                EndTime = result.EndTime,
                Status = result.Status.ToString(),
                CustomerNote = result.CustomerNote,
                CancellationReason = result.CancellationReason,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            };
        }
    }
}
