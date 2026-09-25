using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Infrastructure.Mapper.Service;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Service.GetAvailableServices
{
    public class GetAvailableServicesUseCase
    {
        private readonly AppDbContext _context;

        public GetAvailableServicesUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageableResult<GetAvailableServicesResult>> ExecuteAsync(
            GetAvailableServicesCommand command)
        {
            var query = _context.Services
                .AsNoTracking()
                .Where(service => !service.IsLocked);

            if (!string.IsNullOrWhiteSpace(command.SearchName))
            {
                string searchName = command.SearchName.Trim().ToLower();

                query = query.Where(service =>
                    service.Name.ToLower().Contains(searchName));
            }

            return await query
                .OrderByDescending(service => service.CreatedAt)
                .ThenByDescending(service => service.Id)
                .Select(service => GetAvailableServicesMapper.ToResult(service))
                .ToPaginatedAsync(command.Page, command.Size);
        }
    }
}
