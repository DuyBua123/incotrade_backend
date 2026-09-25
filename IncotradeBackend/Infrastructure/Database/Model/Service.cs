using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IncotradeBackend.Infrastructure.Database.Model
{
    [Table("Services")]
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty!;

        public string? Description { get; set; }

        [Required]
        public int DurationMinutes { get; set; }

        [Required]
        public long Price { get; set; }

        public bool IsLocked { get; set; } = false;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;


        // Relationships
        public ICollection<Booking> Bookings { get; set; } = [];
    }
}
