using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IncotradeBackend.Infrastructure.Database.Enum;

namespace IncotradeBackend.Infrastructure.Database.Model
{
    [Table("Bookings")]
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string BookingCode { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        public DateOnly ServedDate { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public BookingStatus Status { get; set; } = BookingStatus.PENDING;

        [MaxLength(255)]
        public string? CustomerNote { get; set; }

        [MaxLength(255)]
        public string? CancellationReason { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;


        // Relationships
        [ForeignKey("CustomerId")]
        public User Customer { get; set; } = null!;

        [ForeignKey("ServiceId")]
        public Service Service { get; set; } = null!;

        [ForeignKey("StaffId")]
        public Staff Staff { get; set; } = null!;
    }
}
