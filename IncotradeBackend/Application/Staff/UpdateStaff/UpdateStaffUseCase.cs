using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.UpdateStaff
{
    public class UpdateStaffUseCase
    {
        private readonly AppDbContext _context;

        public UpdateStaffUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateStaffResult> ExecuteAsync(
            UpdateStaffCommand command)
        {
            var staff = await _context.Staffs
                .FirstOrDefaultAsync(staff => staff.Id == command.StaffId);

            if (staff == null)
            {
                throw new NotFoundException("Nhân viên không tồn tại.");
            }

            string email = command.Email.ToLower();

            bool isEmailDuplicated = await _context.Staffs
                .AsNoTracking()
                .AnyAsync(staff =>
                    staff.Id != command.StaffId
                    && staff.Email.ToLower() == email);

            if (isEmailDuplicated)
            {
                throw new DuplicatedException("Email nhân viên đã tồn tại.");
            }

            staff.FullName = command.FullName;
            staff.Email = command.Email;
            staff.UpdatedAt = DateTimeOffset.UtcNow;

            if (command.IsLock.HasValue)
            {
                staff.IsLocked = command.IsLock.Value;
            }

            await _context.SaveChangesAsync();

            return UpdateStaffMapper.ToResult(staff);
        }
    }
}
