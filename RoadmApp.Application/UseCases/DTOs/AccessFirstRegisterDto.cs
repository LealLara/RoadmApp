using RoadmApp.Application.Models;
using RoadmApp.Domain.Utils.Contants;
using RoadmApp.Domain.BusinessModel;


namespace RoadmApp.Application.UseCases.Access.CreateAccess
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