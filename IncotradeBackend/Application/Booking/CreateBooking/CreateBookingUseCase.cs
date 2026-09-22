using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Booking.CreateBooking
{
    public class CreateBookingUseCase
    {
        private readonly AppDbContext _context;

        public CreateBookingUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateBookingResult> ExecuteAsync(
            CreateBookingCommand command)
        {
            var service = await _context.Services
                .AsNoTracking()
                .FirstOrDefaultAsync(service => service.Id == command.ServiceId);

            if (service == null)
            {
                throw new NotFoundException("Dịch vụ không tồn tại.");
            }

            if (service.IsLocked)
            {
                throw new ResourceLockedException("Dịch vụ đang bị khóa.");
            }

            var staffSchedule = await _context.WorkSchedules
                .AsNoTracking()
                .Include(schedule => schedule.Staff)
                .FirstOrDefaultAsync(schedule => schedule.Id == command.StaffScheduleId);

            if (staffSchedule == null)
            {
                throw new NotFoundException("Lịch làm việc của nhân viên không tồn tại.");
            }

            if (staffSchedule.Staff.IsLocked)
            {
                throw new ResourceLockedException("Nhân viên đang bị khóa.");
            }

            var today = DateOnly.FromDateTime(DateTime.Now);

            if (staffSchedule.WorkDate <= today)
            {
                throw new InvalidDateException("Ngày phục vụ phải là ngày trong tương lai.");
            }

            var endTime = command.StartTime.AddMinutes(service.DurationMinutes);

            if (command.StartTime < staffSchedule.StartTime
                || endTime > staffSchedule.EndTime)
            {
                throw new InvalidDateException("Thời gian đặt lịch không nằm trong lịch làm việc của nhân viên.");
            }

            bool isBookingOverlapped = await _context.Bookings
                .AsNoTracking()
                .AnyAsync(booking =>
                    booking.StaffId == staffSchedule.StaffId
                    && booking.ServedDate == staffSchedule.WorkDate
                    && booking.Status != BookingStatus.CANCELLED
                    && command.StartTime < booking.EndTime
                    && endTime > booking.StartTime);

            if (isBookingOverlapped)
            {
                throw new DuplicatedException("Thời gian đặt lịch bị trùng với lịch hẹn khác.");
            }

            var booking = CreateBookingMapper.ToEntity(
                command,
                staffSchedule.StaffId,
                staffSchedule.WorkDate,
                endTime,
                GenerateBookingCode());

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return CreateBookingMapper.ToResult(booking);
        }


        // PRIVATE METHODS
        private static string GenerateBookingCode()
        {
            return $"BK{DateTimeOffset.UtcNow:yyyyMMddHHmmssfff}{Guid.NewGuid():N}"[..30];
        }
    }
}
