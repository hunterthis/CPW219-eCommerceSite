using System.ComponentModel.DataAnnotations;

namespace CPW219_eCommerceSite.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; } = null!;
        [Required]
        public string? Name { get; set; }
        public string? password { get; set; }

    }
    public class LoginViewModel 
    {
        [Key]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }

}
