using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncotradeBackend.Infrastructure.Database.Model
{
    [Table("WorkSchedules")]
    public class WorkSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        public DateOnly WorkDate { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;


        // Relationships
        [ForeignKey("StaffId")]
        public Staff Staff { get; set; } = null!;
    }
}
