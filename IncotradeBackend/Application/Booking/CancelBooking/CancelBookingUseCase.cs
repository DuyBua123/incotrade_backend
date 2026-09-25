using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Booking.CancelBooking
{
    public class CancelBookingUseCase
    {
        private readonly AppDbContext _context;

        public CancelBookingUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CancelBookingResult> ExecuteAsync(
            CancelBookingCommand command)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(booking =>
                    booking.Id == command.BookingId
                    && booking.CustomerId == command.CustomerId);

            if (booking == null)
            {
                throw new NotFoundException("Lịch hẹn không tồn tại.");
            }

            if (booking.Status != BookingStatus.PENDING)
            {
                throw new ResourceLockedException("Chỉ có thể hủy lịch hẹn đang chờ xử lý.");
            }

            booking.Status = BookingStatus.CANCELLED;
            booking.CancellationReason = command.CancellationReason.Trim();
            booking.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            return CancelBookingMapper.ToResult(booking);
        }
    }
}
