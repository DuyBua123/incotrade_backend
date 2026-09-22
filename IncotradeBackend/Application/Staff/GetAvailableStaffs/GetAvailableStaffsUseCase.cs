using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.GetAvailableStaffs
{
    public class GetAvailableStaffsUseCase
    {
        private readonly AppDbContext _context;

        public GetAvailableStaffsUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageableResult<GetAvailableStaffsResult>> ExecuteAsync(
            GetAvailableStaffsCommand command)
        {
            var query = _context.Staffs
                .AsNoTracking()
                .Where(staff => !staff.IsLocked);

            if (!string.IsNullOrWhiteSpace(command.SearchFullName))
            {
                string searchFullName = command.SearchFullName.Trim().ToLower();

                query = query.Where(staff =>
                    staff.FullName.ToLower().Contains(searchFullName));
            }

            return await query
                .OrderBy(staff => staff.FullName)
                .ThenBy(staff => staff.Id)
                .Select(GetAvailableStaffsMapper.ToResultExpression())
                .ToPaginatedAsync(command.Page, command.Size);
        }
    }
}
