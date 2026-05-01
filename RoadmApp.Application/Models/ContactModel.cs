using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Application.Models
{
    public class ContactModel
    {
        public int ContactId { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Cellphone { get; private set; } = string.Empty;
        public bool FlagWhatsApp { get; private set; } = true;
        public int UserId { get; private set; }

        public ContactModel() { }
        public ContactModel(string email, string cellphone, bool flagWhatsApp) : this()
        {
            Email = email;
            Cellphone = cellphone;
            FlagWhatsApp = flagWhatsApp;
        }
        public ContactModel(string email) : this()
        {
            Email = email;
        }
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