
using IncotradeBackend.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Infrastructure.Database.Pagination
{
    public static class PaginationQueryable
    {
        public static async Task<PageableResult<T>> ToPaginatedAsync<T>(
            this IQueryable<T> query,
            int page, // 1-based
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            if (page < 1 || pageSize < 1)
                throw new ServerException(
                    "Page and pageSize must be greater than 0."
                );

            long skip = ((long)page - 1) * pageSize;

            long totalItems = await query.LongCountAsync(cancellationToken);

            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var items = await query
                .Skip((int)skip)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var pagination = new Pageable
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                HasNext = page < totalPages,
                HasPrevious = page > 1 && totalPages > 0
            };

            return new PageableResult<T>
            {
                Items = items,
                Pagination = pagination
            };
        }
    }
}