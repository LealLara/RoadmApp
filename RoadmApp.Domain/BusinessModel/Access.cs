using RoadmApp.Domain.Utils.Contants;

namespace RoadmApp.Domain.BusinessModel
{
    public class Access
    {
        public string AccessId { get; private set; } = string.Empty;
        public string Nickname { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool IsBlocked { get; private set; } = false;

        public Access() { }
        public Access(string nickname, string password)
        {
            Nickname = nickname;
            Password = password;
        }
        public Access(string nickname)
        {
            Nickname = nickname;
            Password = PatternAccountConfig.PatternFirstRegister;
        }
        public Access ToBusiness(Register register)
        {
            return new()
            {
                Nickname = register.Access.Nickname,
                Password = PatternAccountConfig.PatternFirstRegister
            };
        }
    }
}