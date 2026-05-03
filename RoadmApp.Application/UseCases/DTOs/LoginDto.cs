using RoadmApp.Application.AplicationModels;

namespace RoadmApp.Application.UseCases.Access.CreateAccess
{
    public class LoginDto
    {
        public string Nickname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public LoginModel Transform()
        {
            return new()
            {
                Nickname = Nickname,
                Password = Password
            };
        }
    }
}