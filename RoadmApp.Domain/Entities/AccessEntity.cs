using System.ComponentModel.DataAnnotations;

namespace RoadmApp.Domain.Entities
{
    public class AccessEntity
    {
        [Key]
        public int AccessId { get; private set; }
        public string Nickname { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool IsBlocked { get; private set; } = false;
        public int UserId { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public AccessEntity() { }
        public AccessEntity(string nickname, string password)
        {
            Nickname = nickname;
            Password = password;
        }
        public AccessEntity(string nickname, string password, int userId, DateTime createdAt, DateTime updatedAt)
        {
            Nickname = nickname;
            Password = password;
            UserId = userId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public AccessEntity(string nickname, string password, int userId, DateTime createdAt)
        {
            Nickname = nickname;
            Password = password;
            UserId = userId;
            CreatedAt = createdAt; 
        }
    }
}