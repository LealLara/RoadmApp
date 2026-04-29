using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.Models
{
    public class RegisterModel
    {
        public AccessModel Access { get; set; } = new();
        public UserModel User { get; set; } = new();
        public List<ContactModel> Contacts { get; set; } = new List<ContactModel>();

        /*public UserEntity TransformToUserEntity()
        {
            return new(
                username: User.Name,
                nickname: Access.Nickname,
                passwordHash: Access.Password,
                birthday: User.Birthday
            );
        }*/
    }
}