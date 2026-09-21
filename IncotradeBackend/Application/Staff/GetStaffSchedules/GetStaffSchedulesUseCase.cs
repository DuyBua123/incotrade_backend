using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.GetStaffSchedules
{
    public class GetStaffSchedulesUseCase
    {
        private readonly AppDbContext _context;

        public GetStaffSchedulesUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageableResult<GetStaffSchedulesResult>> ExecuteAsync(
            GetStaffSchedulesCommand command)
        {
            bool isStaffExisted = await _context.Staffs
                .AsNoTracking()
                .AnyAsync(staff => staff.Id == command.StaffId);

            if (!isStaffExisted)
            {
                throw new NotFoundException("Nhân viên không tồn tại.");
            }

            return await _context.WorkSchedules
                .AsNoTracking()
                .Where(schedule => schedule.StaffId == command.StaffId)
                .OrderBy(schedule => schedule.WorkDate)
                .ThenBy(schedule => schedule.StartTime)
                .Select(schedule => GetStaffSchedulesMapper.ToResult(schedule))
                .ToPaginatedAsync(command.Page, command.Size);
        }
    }
}
