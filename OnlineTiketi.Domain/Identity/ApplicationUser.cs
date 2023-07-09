using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTiketi.Domain.DomainModels.Identity
{
    public class ApplicationUser
    {
        [Key]
        public string UserId { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string NormalizesUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public string EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecyrityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public int PhoneNumber { get; set; }
    }
}
