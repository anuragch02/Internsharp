using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace InternSharp.Models
{
    public class SignUpModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must contains 8 letters.", MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }
        public int AccountTypeId { get; set; }
        public List<SelectListItem> AccountTypes { get; set; }
    }
}
