using RoadmApp.Domain.Entities;

namespace RoadmApp.Api.DTOs
{
    public class AccessDto
    {
        public string Nickname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Access Transform()
        {
            return new(
                nickname: Nickname,
                password: Password
            );
        }
    }
}