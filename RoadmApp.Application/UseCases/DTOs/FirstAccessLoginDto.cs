using RoadmApp.Application.AplicationModels;

namespace RoadmApp.Application.UseCases.DTOs
{
    public class FirstAccessLoginDto
    {
        public string Nickname { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmNewPassword { get; set; } = string.Empty;

        public FirstAccessLoginModel Transform()
        {
            return new()
            {
                Nickname = Nickname,
                NewPassword = NewPassword,
                ConfirmNewPassword = ConfirmNewPassword
            };
        }
    }
}