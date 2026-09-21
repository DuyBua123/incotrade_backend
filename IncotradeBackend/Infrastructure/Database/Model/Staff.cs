using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncotradeBackend.Infrastructure.Database.Model
{
    [Table("Staffs")]
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public bool IsLocked { get; set; } = true;

        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public ICollection<WorkSchedule> WorkSchedules { get; set; } = [];
    }
}
