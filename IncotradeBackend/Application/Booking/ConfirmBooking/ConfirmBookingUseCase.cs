using System.Globalization;
using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using IncotradeBackend.Infrastructure.WebSocket;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Booking.ConfirmBooking
{
    public class ConfirmBookingUseCase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<UpdateBookingStatusNotificationHub> _hubContext;

        public ConfirmBookingUseCase(
            AppDbContext context,
            IHubContext<UpdateBookingStatusNotificationHub> hubContext
        )
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<ConfirmBookingResult> ExecuteAsync(
            ConfirmBookingCommand command)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(booking => booking.Id == command.BookingId);

            if (booking == null)
            {
                throw new NotFoundException("Lịch hẹn không tồn tại.");
            }

            if (booking.Status != BookingStatus.PENDING)
            {
                throw new ResourceLockedException("Chỉ có thể xác nhận lịch hẹn đang chờ xử lý.");
            }

            booking.Status = BookingStatus.CONFIRMED;
            booking.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            await _hubContext.Clients
                .User(booking.CustomerId.ToString())
                .SendAsync(
                    "ReceiveUpdatingBookingStatusMessage", 
                    $"Lịch hẹn vào ngày {booking.ServedDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)} đã được xác nhận");

            return ConfirmBookingMapper.ToResult(booking);
        }
    }
}
