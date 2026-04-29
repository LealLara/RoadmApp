using System.ComponentModel.DataAnnotations;

namespace RoadmApp.Domain.Entities
{
    public class ContactEntity
    {
        [Key]
        public int ContactId { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string Cellphone { get; private set; } = string.Empty;
        public bool FlagWhatsApp { get; private set; } = false;
        public int UserId { get; private set; }

        public ContactEntity() { }
        public ContactEntity(string email, string cellphone, bool flagWhatsApp) : this()
        {
            Email = email;
            Cellphone = cellphone;
            FlagWhatsApp = flagWhatsApp;
        }
        public ContactEntity(string email) : this()
        {
            Email = email;
        }
    }
}