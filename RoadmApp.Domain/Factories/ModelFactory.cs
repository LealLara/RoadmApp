using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Factories
{
    public static class ModelFactory
    {
        public static LogModel CreateLogModel(LogEntity logEntity)
        {
            return new LogModel(

                logId: logEntity.LogId,
                logMessage: logEntity.LogMessage,
                logTypeId: logEntity.LogTypeId,
                userId: logEntity.UserId,
                createdAt: logEntity.CreatedAt
            );
        }

        public static LogEntity CreateLogEntity(LogModel logModel)
        {
            return new LogEntity(
                logMessage: logModel.LogMessage,
                logTypeId: logModel.LogTypeId,
                userId: logModel.UserId,
                createdAt: DateTime.Now
            );
        }
        public static UserEntity CreateUserEntity(RegisterModel registerModel)
        {
            return new UserEntity(
                nickname: registerModel.Access.Nickname,
                passwordHash: registerModel.Access.Password,
                contacts: registerModel.Contacts.Select(c => c.Email != null ? c.Email : string.Empty).ToList()
            );
        }

        public static UserModel CreateUserModel(UserEntity userEntity)
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