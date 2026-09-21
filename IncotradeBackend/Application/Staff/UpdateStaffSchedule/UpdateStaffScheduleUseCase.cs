using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.UpdateStaffSchedule
{
    public class UpdateStaffScheduleUseCase
    {
        private readonly AppDbContext _context;

        public UpdateStaffScheduleUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateStaffScheduleResult> ExecuteAsync(
            UpdateStaffScheduleCommand command)
        {
            var schedule = await _context.WorkSchedules
                .FirstOrDefaultAsync(schedule =>
                    schedule.Id == command.StaffScheduleId);

            if (schedule == null)
            {
                throw new NotFoundException("Lịch làm việc không tồn tại.");
            }

            bool isStaffExisted = await _context.Staffs
                .AsNoTracking()
                .AnyAsync(staff => staff.Id == command.StaffId);

            if (!isStaffExisted)
            {
                throw new NotFoundException("Nhân viên không tồn tại.");
            }

            bool isScheduleOverlapped = await _context.WorkSchedules
                .AsNoTracking()
                .AnyAsync(otherSchedule =>
                    otherSchedule.Id != command.StaffScheduleId
                    && otherSchedule.StaffId == command.StaffId
                    && otherSchedule.WorkDate == command.WorkDate
                    && command.StartTime < otherSchedule.EndTime
                    && command.EndTime > otherSchedule.StartTime);

            if (isScheduleOverlapped)
            {
                throw new DuplicatedException("Lịch làm việc bị trùng thời gian.");
            }

            schedule.StaffId = command.StaffId;
            schedule.WorkDate = command.WorkDate;
            schedule.StartTime = command.StartTime;
            schedule.EndTime = command.EndTime;
            schedule.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            return UpdateStaffScheduleMapper.ToResult(schedule);
        }
    }
}
