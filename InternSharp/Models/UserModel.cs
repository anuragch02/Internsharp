using System.ComponentModel.DataAnnotations;

namespace InternSharp.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }       
        public bool IsActive { get; set; }
        public int AccountTypeId { get; set; }
    }
}
