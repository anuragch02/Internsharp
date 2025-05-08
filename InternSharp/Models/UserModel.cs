using System.ComponentModel.DataAnnotations;

namespace InternSharp.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }       
        public bool IsActive { get; set; }
    }
}
