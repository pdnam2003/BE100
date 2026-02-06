using BE100.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE100.Entities
{
    [Table("AppUser")] 
    public class AppUser
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public Role Role { get; set; }

        public ICollection<ExamHistory> ExamHistories { get; set; } = new List<ExamHistory>();
        public ICollection<RefreshToken> RefreshTokens { get; set; }
           = new List<RefreshToken>();

    }
}
