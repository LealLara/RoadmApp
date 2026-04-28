using RoadmApp.Domain.Models;

namespace RoadmApp.Api.DTOs
{
    public class RegisterDto
    { 
        public AccessDto Access { get; set; } = new ();       
        public UserDto User { get; set; } = new ();       
        public string ConfirmPassword { get; set; } = string.Empty;
       public List<ContactDto> Contacts { get; set; } = new List<ContactDto>();     
        
        public Register Transform()
        {
            return new()
            {
                Access = Access.Transform(),
                User = User.Transform(),
                ConfirmPassword = ConfirmPassword,
                Contacts = Contacts.Select(c => c.Transform()).ToList()
            };
        }
    }
}