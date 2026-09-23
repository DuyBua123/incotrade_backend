using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Booking.CompleteBooking
{
    public class CompleteBookingUseCase
    {
        private readonly AppDbContext _context;

        public CompleteBookingUseCase(AppDbContext context)
        {
            _context = context;
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

            return CompleteBookingMapper.ToResult(booking);
        }
    }
}
