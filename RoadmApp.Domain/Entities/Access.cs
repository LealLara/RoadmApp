namespace RoadmApp.Domain.Entities
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
    }
}