using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Service;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Service.GetService
{
    public class GetServiceUseCase
    {
        private readonly AppDbContext _context;

        public GetServiceUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetServiceResult> ExecuteAsync(
            GetServiceCommand command)
        {
            var service = await _context.Services
                .AsNoTracking()
                .FirstOrDefaultAsync(service => service.Id == command.ServiceId);

            if (service == null)
            {
                throw new NotFoundException("Dịch vụ không tồn tại.");
            }

            return GetServiceMapper.ToResult(service);
        }
    }
}
