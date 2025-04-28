using System.ComponentModel.DataAnnotations;

namespace InternSharp.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
