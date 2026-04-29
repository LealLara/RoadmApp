using RoadmApp.Domain.Models;

namespace RoadmApp.Api.DTOs
{
    public class ContactDto
    {
        public string Cellphone { get; set; } = string.Empty;
        public bool FlagWhatsApp { get; set; } = true;
        public string Email { get; set; } = string.Empty;

        public ContactModel Transform()
        {
            return new(
                email: Email,
                cellphone: Cellphone,
                flagWhatsApp: FlagWhatsApp
            );
        }
    }
}