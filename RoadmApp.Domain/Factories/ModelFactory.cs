using RoadmApp.Domain.Entities;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Factories
{
    public static class ModelFactory
    {
        public static Log CreateLogModel(LogEntity logEntity)
        {
            return new Log(

                logId: logEntity.LogId,
                logMessage: logEntity.LogMessage,
                logTypeId: logEntity.LogTypeId,
                userId: logEntity.UserId,
                createdAt: logEntity.CreatedAt
            );
        }

        public static LogEntity CreateLogEntity(Log log)
        {
            return new LogEntity(
                logMessage: log.LogMessage,
                logTypeId: log.LogTypeId,
                userId: log.UserId,
                createdAt: DateTime.Now
            );
        }
        public static UserEntity CreateUserEntity(Register register)
        {
            return new UserEntity(
                nickname: register.Access.Nickname,
                passwordHash: register.Access.Password,
                contacts: register.Contacts.Select(c => c.Email != null ? c.Email : string.Empty).ToList()
            );
        }

        public static User CreateUserModel(UserEntity userEntity)
        {
            if (userEntity == null)
                return null;

            return new(
                userId: userEntity.UserId,
                nickname: userEntity.Nickname,
                name: userEntity.Name,
                birthday: userEntity.Birthday
            );
        }
    }
}