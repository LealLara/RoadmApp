using RoadmApp.Domain.Utils.Contants;

namespace RoadmApp.Domain.BusinessModel
{
    public class Access
    {
        public int AccessId { get; private set; }
        public string Nickname { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool IsBlocked { get; private set; } = false;
        public int UserId { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public Access() { }
        public Access(string nickname, string password)
        {
            Nickname = nickname;
            Password = password;
        }
        public Access(int accessId, string nickname, string password, bool isBlocked, int userId, DateTime createdAt, DateTime updatedAt)
        {
            AccessId = accessId;
            Nickname = nickname;
            Password = password;
            IsBlocked = isBlocked;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public Access(int accessId, string nickname, string password, bool isBlocked, int userId, DateTime createdAt)
        {
            AccessId = accessId;
            Nickname = nickname;
            Password = password;
            IsBlocked = isBlocked;
            UserId = userId;
            CreatedAt = createdAt; 
        }
        public Access(int accessId, string nickname, string password, bool isBlocked)
        {
            AccessId = accessId;
            Nickname = nickname;
            Password = password;
            IsBlocked = isBlocked;
        }
        public Access(string nickname)
        {
            Nickname = nickname;
            Password = BCrypt.Net.BCrypt.HashPassword(PatternAccountConfig.PatternFirstRegister);
        }
        public Access ToBusiness(Register register)
        {
            return new()
            {
                Nickname = register.Access.Nickname,
                Password = register.Access.Password,
            };
        }

    }
}