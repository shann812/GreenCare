namespace GreenCareApi.Infrastructure.Security
{
    public static class PasswordHeasher
    {
        public static string HashPassword(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);

        public static bool Verify(string password, string hashedPassword)
            => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
