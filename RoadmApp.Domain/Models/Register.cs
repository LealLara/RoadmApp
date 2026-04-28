using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.Models
{
    public class Register
    { 
        public Access Access { get; set; } = new();
        public User User { get; set; } = new();
        public string ConfirmPassword { get; set; } = string.Empty;
        public List<Contact> Contacts { get; set; } = new List<Contact>();

    }
}