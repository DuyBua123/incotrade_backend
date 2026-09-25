using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Staff;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Staff.CreateStaff
{
    public class CreateStaffUseCase
    {
        private readonly AppDbContext _context;

        public CreateStaffUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateStaffResult> ExecuteAsync(
            CreateStaffCommand command)
        {
            string email = command.Email.ToLower();

            bool isEmailDuplicated = await _context.Staffs
                .AsNoTracking()
                .AnyAsync(staff => staff.Email.ToLower() == email);

            if (isEmailDuplicated)
            {
                throw new DuplicatedException("Email nhân viên đã tồn tại.");
            }

            var staff = CreateStaffMapper.ToEntity(command);

            await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();

            return CreateStaffMapper.ToResult(staff);
        }
    }
}
