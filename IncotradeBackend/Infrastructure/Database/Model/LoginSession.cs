
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IncotradeBackend.Infrastructure.Database.Enum;


namespace IncotradeBackend.Infrastructure.Database.Model
{
    [Table("LoginSessions")]
    public class LoginSession
    {

        [Key]
        public int Id { get; set; }
        public string HashedRefreshToken { get; set; } = string.Empty;
        public RevokedReason? RevokedReason { get; set; }
        public DateTimeOffset AccessExpiresAt { get; set; }
        public DateTimeOffset RefreshExpiresAt { get; set; }
        public DateTimeOffset? RevokedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;


        // Relationships
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        
    }
}