using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.CreateStaffSchedule
{
    public class CreateStaffScheduleUseCase
    {
        private readonly AppDbContext _context;

        public CreateStaffScheduleUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateStaffScheduleResult> ExecuteAsync(
            CreateStaffScheduleCommand command)
        {
            bool isStaffExisted = await _context.Staffs
                .AsNoTracking()
                .AnyAsync(staff => staff.Id == command.StaffId);

            if (!isStaffExisted)
            {
                throw new NotFoundException("Nhân viên không tồn tại.");
            }

            bool isScheduleOverlapped = await _context.WorkSchedules
                .AsNoTracking()
                .AnyAsync(schedule =>
                    schedule.StaffId == command.StaffId
                    && schedule.WorkDate == command.WorkDate
                    && command.StartTime < schedule.EndTime
                    && command.EndTime > schedule.StartTime);

            if (isScheduleOverlapped)
            {
                throw new DuplicatedException("Lịch làm việc bị trùng thời gian.");
            }

            var schedule = CreateStaffScheduleMapper.ToEntity(command);

            await _context.WorkSchedules.AddAsync(schedule);
            await _context.SaveChangesAsync();

            return CreateStaffScheduleMapper.ToResult(schedule);
        }
    }
}
