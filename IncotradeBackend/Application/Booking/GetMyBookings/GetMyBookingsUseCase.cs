using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Pagination;
using IncotradeBackend.Infrastructure.Mapper.Booking;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Booking.GetMyBookings
{
    public class GetMyBookingsUseCase
    {
        private readonly AppDbContext _context;

        public GetMyBookingsUseCase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PageableResult<GetMyBookingsResult>> ExecuteAsync(
            GetMyBookingsCommand command)
        {
            var query = _context.Bookings
                .AsNoTracking()
                .Include(b => b.Service)
                .Include(s => s.Staff)
                .Where(booking => booking.CustomerId == command.CustomerId);

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
                .Select(booking => GetMyBookingsMapper.ToResult(booking))
                .ToPaginatedAsync(command.Page, command.Size);
        }
    }
}
