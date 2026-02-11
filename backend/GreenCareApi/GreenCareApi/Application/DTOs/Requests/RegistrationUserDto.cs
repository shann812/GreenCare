using System.ComponentModel.DataAnnotations;

namespace GreenCareApi.Application.DTOs.Requests
{
    public class RegistrationUserDto
    {
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
