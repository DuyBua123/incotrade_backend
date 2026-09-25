using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Mapper.Service;

namespace IncotradeBackend.Application.Service.CreateService
{
    public class CreateServiceUseCase
    {
        private readonly AppDbContext _context;

        public CreateServiceUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateServiceResult> ExecuteAsync(
            CreateServiceCommand command)
        {
            var service = CreateServiceMapper.ToEntity(command);

            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();

            return CreateServiceMapper.ToResult(service);
        }
    }
}
