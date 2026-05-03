using RoadmApp.Application.Responses;

namespace RoadmApp.Application.UseCases.Access.CreateAccess
{
    public class RegisterDto
    {
        public AccessFirstRegisterDto Access { get; set; } = new();
        public UserDto User { get; set; } = new();
        public ContactDto Contacts { get; set; } = new ContactDto();

        public RegisterModel Transform()
        {
            return new()
            {
                Access = Access.Transform(),
                User = User.Transform(),
                Contacts = Contacts.Transform()
            };
        }
    }
}