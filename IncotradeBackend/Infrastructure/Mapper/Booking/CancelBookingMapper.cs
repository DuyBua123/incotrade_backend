using IncotradeBackend.Application.Booking.CancelBooking;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Booking
{
    public static class CancelBookingMapper
    {
        public static CancelBookingCommand ToCommand(
            CancelBookingRequest request,
            int customerId)
        {
            return new CancelBookingCommand
            {
                BookingId = int.Parse(request.BookingId),
                CustomerId = customerId,
                CancellationReason = request.CancellationReason
            };
        }

        public static CancelBookingResult ToResult(
            Database.Model.Booking booking)
        {
            return new CancelBookingResult
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

        public static CancelBookingResponse ToResponse(
            CancelBookingResult result)
        {
            return new CancelBookingResponse
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
