using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;

namespace RoadmApp.Application.Responses
{
    public class AccessModel
    {
        public string AccessId { get; private set; } = string.Empty;
        public string Nickname { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool IsBlocked { get; private set; } = false;
        public int UserId { get; private set; } 

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

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
        public AccessModel(string nickname, string password, bool isBlocked, int userId, DateTime createdAt)
        {
            Nickname = nickname;
            Password = password;
            IsBlocked = isBlocked;
            UserId = userId;
            CreatedAt = createdAt;
        }
        public AccessModel(string nickname, string password, bool isBlocked, int userId, DateTime createdAt, DateTime updatedAt)
        {
            Nickname = nickname;
            Password = password;
            IsBlocked = isBlocked;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public AccessEntity TransformToAccessEntity()
        {
            return new (
                 nickname: Nickname,
                 password: Password, 
                 userId: UserId,
                 createdAt: CreatedAt
            );   
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