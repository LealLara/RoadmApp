using RoadmApp.Domain.Models;

namespace RoadmApp.Api.DTOs
{
    public class RegisterDto
    { 
        public AccessFirstRegisterDto Access { get; set; } = new ();       
        public UserDto User { get; set; } = new ();        
       public List<ContactDto> Contacts { get; set; } = new List<ContactDto>();     
        
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