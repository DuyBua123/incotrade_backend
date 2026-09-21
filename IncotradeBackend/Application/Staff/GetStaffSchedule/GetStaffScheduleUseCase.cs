using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.GetStaffSchedule
{
    public class GetStaffScheduleUseCase
    {
        private readonly AppDbContext _context;

        public GetStaffScheduleUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetStaffScheduleResult> ExecuteAsync(
            GetStaffScheduleCommand command)
        {
            var schedule = await _context.WorkSchedules
                .AsNoTracking()
                .FirstOrDefaultAsync(schedule =>
                    schedule.Id == command.StaffScheduleId);

            if (schedule == null)
            {
                throw new NotFoundException("Lịch làm việc không tồn tại.");
            }

            return GetStaffScheduleMapper.ToResult(schedule);
        }
    }
}
