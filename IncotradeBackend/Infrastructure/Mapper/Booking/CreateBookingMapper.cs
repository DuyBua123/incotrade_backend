using IncotradeBackend.Application.Booking.CreateBooking;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Booking
{
    public static class CreateBookingMapper
    {
        public static CreateBookingCommand ToCommand(
            CreateBookingRequest request,
            int customerId)
        {
            return new CreateBookingCommand
            {
                CustomerId = customerId,
                ServiceId = int.Parse(request.ServiceId),
                StaffScheduleId = int.Parse(request.StaffScheduleId),
                StartTime = TimeOnly.Parse(request.StartTime),
                CustomerNote = request.CustomerNote
            };
        }

        public static Database.Model.Booking ToEntity(
            CreateBookingCommand command,
            int staffId,
            DateOnly servedDate,
            TimeOnly endTime,
            string bookingCode)
        {
            return new Database.Model.Booking
            {
                BookingCode = bookingCode,
                CustomerId = command.CustomerId,
                ServiceId = command.ServiceId,
                StaffId = staffId,
                ServedDate = servedDate,
                StartTime = command.StartTime,
                EndTime = endTime,
                CustomerNote = command.CustomerNote
            };
        }

        public static CreateBookingResult ToResult(
            Database.Model.Booking booking)
        {
            return new CreateBookingResult
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
                CreatedAt = booking.CreatedAt,
                UpdatedAt = booking.UpdatedAt
            };
        }

        public static CreateBookingResponse ToResponse(
            CreateBookingResult result)
        {
            return new CreateBookingResponse
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
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt
            };
        }
    }
}
