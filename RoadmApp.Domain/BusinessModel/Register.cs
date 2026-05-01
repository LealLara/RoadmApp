namespace RoadmApp.Domain.BusinessModel
{
    public class Register
    {
        public Access Access { get; set; } = new();
        public User User { get; set; } = new();
        public List<Contact> Contacts { get; set; } = new List<Contact>();

    }
}