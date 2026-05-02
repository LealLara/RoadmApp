namespace RoadmApp.Domain.BusinessModel
{
    public class Register
    {
        public Access Access { get; set; } = new();
        public User User { get; set; } = new();
        public Contact Contacts { get; set; } = new Contact();

    }
}