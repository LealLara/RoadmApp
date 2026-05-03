using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Application.Responses
{
    public class RegisterModel
    {
        public AccessModel Access { get; set; } = new();
        public UserModel User { get; set; } = new();
        public ContactModel Contacts { get; set; } = new ContactModel();


        public Register ToBusiness()
           {
               return new()
               {
                   Access = Access.ToBusiness(),
                   User = User.ToBusiness(),
                   Contacts = Contacts.ToBusiness()
               };
           }
    }
}