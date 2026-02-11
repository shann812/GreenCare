namespace GreenCareApi.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public string UserName { get; set; } = null!;
        public string? Bio { get; set; }
        public DateOnly? BirthDate { get; set; }
        public bool IsProfilePublic { get; set; } = true;
        public string? ProfileImagePath { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
