using System.ComponentModel.DataAnnotations;

namespace ProductAPP.DTO
{
    public class LoginDTO{
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}