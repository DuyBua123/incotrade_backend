
using IncotradeBackend.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Infrastructure.CronJob
{
    public class CleanupOverdueBooking
    {
        
        private readonly AppDbContext _context;

        public CleanupOverdueBooking(
            AppDbContext context
        )
        {
            _context = context;
        }


        public async Task ExecuteAsync()
        {
            Console.WriteLine("===========START CLEANUP OVERDUE BOOKING===========");
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly overdueThreshold = today.AddDays(-7); // Overdue 7 days

            var overdueBookings = await _context.Bookings
                .Where(b => b.ServedDate <= overdueThreshold)
                .ToListAsync();

            _context.Bookings.RemoveRange(overdueBookings);
            await _context.SaveChangesAsync();
            Console.WriteLine("===========END CLEANUP OVERDUE BOOKING===========");
        }

    }
}