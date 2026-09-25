using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Service;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Service.UpdateService
{
    public class UpdateServiceUseCase
    {
        private readonly AppDbContext _context;

        public UpdateServiceUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateServiceResult> ExecuteAsync(
            UpdateServiceCommand command)
        {
            var service = await _context.Services
                .FirstOrDefaultAsync(service => service.Id == command.ServiceId);

            if (service == null)
            {
                throw new NotFoundException("Dịch vụ không tồn tại.");
            }

            service.Name = command.ServiceName;
            service.Description = command.Description;
            service.DurationMinutes = command.DurationMinutes;
            service.Price = command.Price;
            service.UpdatedAt = DateTimeOffset.UtcNow;

            if (command.IsLock.HasValue)
            {
                service.IsLocked = command.IsLock.Value;
            }

            await _context.SaveChangesAsync();

            return UpdateServiceMapper.ToResult(service);
        }
    }
}
