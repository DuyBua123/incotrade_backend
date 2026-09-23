using IncotradeBackend.Application.Booking.CompleteBooking;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Booking
{
    public static class CompleteBookingMapper
    {
        public static CompleteBookingCommand ToCommand(
            CompleteBookingRequest request)
        {
            return new CompleteBookingCommand
            {
                BookingId = int.Parse(request.BookingId)
            };
        }

        public static CompleteBookingResult ToResult(
            Database.Model.Booking booking)
        {
            return new CompleteBookingResult
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

        public static CompleteBookingResponse ToResponse(
            CompleteBookingResult result)
        {
            return new CompleteBookingResponse
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
