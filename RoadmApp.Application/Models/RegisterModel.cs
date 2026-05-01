namespace RoadmApp.Application.Models
{
    public class RegisterModel
    {
        public AccessModel Access { get; set; } = new();
        public UserModel User { get; set; } = new();
        public List<ContactModel> Contacts { get; set; } = new List<ContactModel>();
    }
}