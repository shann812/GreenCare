using System.ComponentModel.DataAnnotations;

namespace GreenCareApi.Application.DTOs
{
    public class RegistrationUserDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }
    }
}
