using RoadmApp.Domain.Models;
using RoadmApp.Domain.Utils.Contants;

namespace RoadmApp.Api.DTOs
{
    public class AccessFirstRegisterDto
    {

        public string Nickname { get; set; } = string.Empty; 

        public AccessModel Transform()
        {
            return new(
                nickname: Nickname,
                password: PatternAccountConfig.PatternFirstRegister
            );
        }
    }
}