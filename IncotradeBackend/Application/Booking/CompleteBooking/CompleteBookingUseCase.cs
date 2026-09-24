using System.Globalization;
using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using IncotradeBackend.Infrastructure.WebSocket;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Booking.CompleteBooking
{
    public class CompleteBookingUseCase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<UpdateBookingStatusNotificationHub> _hubContext;

        public CompleteBookingUseCase(
            AppDbContext context,
            IHubContext<UpdateBookingStatusNotificationHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<CompleteBookingResult> ExecuteAsync(
            CompleteBookingCommand command)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(booking => booking.Id == command.BookingId);

            if (booking == null)
            {
                throw new NotFoundException("Lịch hẹn không tồn tại.");
            }

            if (booking.Status != BookingStatus.CONFIRMED)
            {
                throw new ResourceLockedException("Chỉ có thể hoàn thành lịch hẹn đã được xác nhận.");
            }

            booking.Status = BookingStatus.COMPLETED;
            booking.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            await _hubContext.Clients
                .User(booking.CustomerId.ToString())
                .SendAsync(
                    "ReceiveUpdatingBookingStatusMessage", 
                    $"Lịch hẹn vào ngày {booking.ServedDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} đã được hoàn thành");

            return CompleteBookingMapper.ToResult(booking);
        }
    }
}
