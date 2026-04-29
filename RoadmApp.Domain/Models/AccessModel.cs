using RoadmApp.Domain.Utils.Contants;

namespace RoadmApp.Domain.Models
{
    public class AccessModel
    {
        public string AccessId { get; private set; } = string.Empty;
        public string Nickname { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool IsBlocked { get; private set; } = false;

        public AccessModel() { }
        public AccessModel(string nickname, string password)
        {
            Nickname = nickname;
            Password = password;
        }
        public AccessModel(string nickname)
        {
            Nickname = nickname;
            Password = PatternAccountConfig.PatternFirstRegister;
        }
    }
}