namespace GreenCareApi.Application.DTOs.Responses
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = null!;
        public string RoleName { get; set; } = null!; //idk
        public string UserName { get; set; } = null!;
    }
}
