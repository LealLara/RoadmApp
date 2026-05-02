using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Application.Responses
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
            Password = Password;
        }
        public Access ToBusiness()
        {
            return new(
                nickname: Nickname,
                password: Password

            );
        }
    }
}