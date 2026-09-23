using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Booking.GetBookings
{
    public class GetBookingsUseCase
    {
        private readonly AppDbContext _context;

        public GetBookingsUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageableResult<GetBookingsResult>> ExecuteAsync(
            GetBookingsCommand command)
        {
            var query = _context.Bookings
                .AsNoTracking()
                .Include(booking => booking.Customer)
                .Include(booking => booking.Service)
                .Include(booking => booking.Staff)
                .AsQueryable();

            if (command.ServedDate.HasValue)
            {
                query = query.Where(booking =>
                    booking.ServedDate == command.ServedDate.Value);
            }

            if (command.Status.HasValue)
            {
                query = query.Where(booking =>
                    booking.Status == command.Status.Value);
            }

            return await query
                .OrderByDescending(booking => booking.ServedDate)
                .ThenBy(booking => booking.StartTime)
                .Select(booking => GetBookingsMapper.ToResult(booking))
                .ToPaginatedAsync(command.Page, command.Size);
        }
    }
}
