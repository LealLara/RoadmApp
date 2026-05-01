using RoadmApp.Application.Models;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Application.UseCases.Access.CreateAccess
{
    public class RegisterDto
    {
        public AccessFirstRegisterDto Access { get; set; } = new();
        public UserDto User { get; set; } = new();
        public List<ContactDto> Contacts { get; set; } = new List<ContactDto>();

        public Register ToBusiness()
        {
            return new()
            {
                Access = Access.Transform().ToBusiness(),
                User = User.ToBusiness(),
                Contacts = Contacts.Select(c => c.ToBusiness()).ToList()
            };
        }
        public RegisterModel Transform()
        {
            return new()
            {
                Access = Access.Transform(),
                User = User.Transform(),
                Contacts = Contacts.Select(c => c.Transform()).ToList()
            };
        }
    }
}