using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;

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
            return new (
                username: register.User.Name,
                nickname: register.Access.Nickname,
                passwordHash: register.Access.Password,
                birthday: register.User.Birthday,
                contacts: register.Contacts
            );
        }

        public static User CreateUserModel(UserEntity entity)
        {
            if (entity == null)
                return null;

            return new(
                userId: entity.UserId,
                nickname: entity.Nickname,
                name: entity.Name,
                birthday: entity.Birthday
            );
        }
        public static List<Contact> CreateContactListModel(IList<ContactEntity> entities)
        {
            if (entities == null)
                return null;

            return new(
                entities.Select(e => new Contact(
                    contactId: e.ContactId,
                    email: e.Email,
                    cellphone: e.Cellphone,
                    flagWhatsApp: e.FlagWhatsApp,
                    userId: e.UserId
                ))
            );
        }
        public static Contact CreateContactModel(ContactEntity entity)
        {
            if (entity == null)
                return null;

            return new(
                    contactId: entity.ContactId,
                    email: entity.Email,
                    cellphone: entity.Cellphone,
                    flagWhatsApp: entity.FlagWhatsApp,
                    userId: entity.UserId
            );
        }
    }
}