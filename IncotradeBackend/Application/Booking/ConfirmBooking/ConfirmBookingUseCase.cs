using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Booking.ConfirmBooking
{
    public class ConfirmBookingUseCase
    {
        private readonly AppDbContext _context;

        public ConfirmBookingUseCase(AppDbContext context)
        {
            _context = context;
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

            return ConfirmBookingMapper.ToResult(booking);
        }
    }
}
