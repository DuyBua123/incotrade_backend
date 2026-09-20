using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Infrastructure.Mapper.Service;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Service.GetServices
{
    public class GetServicesUseCase
    {
        private readonly AppDbContext _context;

        public GetServicesUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageableResult<GetServicesResult>> ExecuteAsync(
            GetServicesCommand command)
        {
            var query = _context.Services.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(command.SearchName))
            {
                string searchName = command.SearchName.Trim().ToLower();

                query = query.Where(service =>
                    service.Name.ToLower().Contains(searchName));
            }

            return await query
                // .OrderBy(service => service.Id)
                .Select(service => GetServicesMapper.ToResult(service))
                .ToPaginatedAsync(command.Page, command.Size);
        }
    }
}
