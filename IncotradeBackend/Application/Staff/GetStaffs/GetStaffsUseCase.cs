using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.GetStaffs
{
    public class GetStaffsUseCase
    {
        private readonly AppDbContext _context;

        public GetStaffsUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageableResult<GetStaffsResult>> ExecuteAsync(
            GetStaffsCommand command)
        {
            var query = _context.Staffs.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(command.SearcFullhName))
            {
                string searchName = command.SearcFullhName.Trim().ToLower();

                query = query.Where(staff =>
                    staff.FullName.ToLower().Contains(searchName));
            }

            return await query
                .OrderBy(staff => staff.Id)
                .Select(staff => GetStaffsMapper.ToResult(staff))
                .ToPaginatedAsync(command.Page, command.Size);
        }
    }
}
