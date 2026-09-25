using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.GetStaff
{
    public class GetStaffUseCase
    {
        private readonly AppDbContext _context;

        public GetStaffUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetStaffResult> ExecuteAsync(
            GetStaffCommand command)
        {
            var staff = await _context.Staffs
                .AsNoTracking()
                .FirstOrDefaultAsync(staff => staff.Id == command.StaffId);

            if (staff == null)
            {
                throw new NotFoundException("Nhân viên không tồn tại.");
            }

            return GetStaffMapper.ToResult(staff);
        }
    }
}
