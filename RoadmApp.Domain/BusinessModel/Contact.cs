using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.BusinessModel
{
    public class Contact
    {
        public int ContactId { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Cellphone { get; private set; } = string.Empty;
        public bool FlagWhatsApp { get; private set; } = true;
        public int UserId { get; private set; }

        public Contact() { }
        public Contact(string email, string cellphone, bool flagWhatsApp) : this()
        {
            Email = email;
            Cellphone = cellphone;
            FlagWhatsApp = flagWhatsApp;
        }
        public Contact(string email, string cellphone, bool flagWhatsApp, int userId) : this()
        {
            Email = email;
            Cellphone = cellphone;
            FlagWhatsApp = flagWhatsApp;
            UserId = userId;
        }
        public Contact(int contactId, string email, string cellphone, bool flagWhatsApp, int userId) : this()
        {
            ContactId = contactId;
            Email = email;
            Cellphone = cellphone;
            FlagWhatsApp = flagWhatsApp;
            UserId = userId;
        }
        public Contact(string email) : this()
        {
            Email = email;
        }
   
        public ContactEntity TransformToContactEntity(Contact user)
        {
            return new(
                email: Email,
                cellphone: Cellphone,
                flagWhatsApp: FlagWhatsApp,
                userId: user.UserId
            );
        }
    }
}