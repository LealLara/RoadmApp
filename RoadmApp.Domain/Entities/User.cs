using RoadmApp.Domain.Models;
using System.Xml.Linq;

namespace RoadmApp.Domain.Entities
{
    public class User
    { 
        public int UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Nickname { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; }
        public DateTime Birthday { get; private set; } = DateTime.Today;
        public ICollection<Contact> Contacts { get; private set; } = new List<Contact>(); 

        public User() { }
        public User(string nickname, string passwordHash)
        {
            Nickname = nickname;
            PasswordHash = passwordHash;
        }
        public User(string name, DateTime birthday) {
            Name = name;    
            Birthday = birthday;
        }
        public void SetPassword(string hash)
        {
            PasswordHash = hash;
        }
        

        public User Transform(Register register)
        {
            return new ()
            {
                Name = register.User.Name,
                Birthday = register.User.Birthday,
                Nickname = register.User.Nickname,
                PasswordHash = register.Access.Password,
                Contacts = register.Contacts,
            };
        }
        public User TransformResult()
        {
            return new ()
            {
                Name = Name,
                Birthday = Birthday
            };
        }
    }
}