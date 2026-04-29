using RoadmApp.Domain.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace RoadmApp.Domain.Entities
{
    public class LogEntity
    {
        [Key]
        public int LogId { get; private set; }
        public string LogMessage { get; private set; }
        public int LogTypeId { get; private set; }
        public int UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public LogEntity() { }
        public LogEntity(string logMessage, int logTypeId, int userId, DateTime createdAt) : this()
        {
            LogMessage = logMessage;
            LogTypeId = logTypeId;
            UserId = userId;
            CreatedAt = createdAt;
        }
        public LogEntity(int logId, string logMessage, int logTypeId, int userId, DateTime createdAt) : this()
        {
            LogId = logId;
            LogMessage = logMessage;
            LogTypeId = logTypeId;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public LogEntity(string logMessage, int logTypeId, int userId) : this()
        {
            LogMessage = logMessage;
            LogTypeId = logTypeId;
            UserId = userId;
        }
        public LogEntity CreateAccessLogAndTransform(string createdUser, int userId)
        {
            return new(
                logMessage: $"Novo usuário criado: {createdUser}",
                logTypeId: (int)ELogType.Creation,
                userId: userId
           );
        }
        public LogEntity Transform()
        {
            return new(
                logId: LogId,
                logMessage: LogMessage,
                logTypeId: LogTypeId,
                userId: UserId,
                createdAt: DateTime.Now
            );
        }
    }
}