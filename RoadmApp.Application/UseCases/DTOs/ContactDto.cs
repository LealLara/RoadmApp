using RoadmApp.Application.Responses;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Application.UseCases.Access.CreateAccess
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
        public Contact ToBusiness()
        {
            return new(
                email: Email,
                cellphone: Cellphone,
                flagWhatsApp: FlagWhatsApp
            );
        }
    }
}