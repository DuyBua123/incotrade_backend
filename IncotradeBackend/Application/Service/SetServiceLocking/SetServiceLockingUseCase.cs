using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Service;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Service.SetServiceLocking
{
    public class SetServiceLockingUseCase
    {
        private readonly AppDbContext _context;

        public SetServiceLockingUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SetServiceLockingResult> ExecuteAsync(
            SetServiceLockingCommand command)
        {
            var service = await _context.Services
                .FirstOrDefaultAsync(service => service.Id == command.ServiceId);

            if (service == null)
            {
                throw new NotFoundException("Dịch vụ không tồn tại.");
            }

            service.IsLocked = command.IsLock;
            service.UpdatedAt = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            return SetServiceLockingMapper.ToResult(service);
        }
    }
}
