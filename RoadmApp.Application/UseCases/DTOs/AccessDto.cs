using RoadmApp.Application.Models;

namespace RoadmApp.Application.UseCases.Access.CreateAccess
{
    public class AccessDto
    {
        public string Nickname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public AccessModel Transform()
        {
            return new(
                nickname: Nickname,
                password: Password
            );
        }  
    }
}