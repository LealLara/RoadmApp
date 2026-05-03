using RoadmApp.Application.Responses;
using RoadmApp.Domain.Utils.Contants;


namespace RoadmApp.Application.UseCases.Access.CreateAccess
{
    public class AccessFirstRegisterDto
    {
        public string Nickname { get; set; } = string.Empty;

        public AccessModel Transform()
        {
            return new(
                nickname: Nickname,
                password: BCrypt.Net.BCrypt.HashPassword(PatternAccountConfig.PatternFirstRegister)
            );
        }
    }
}