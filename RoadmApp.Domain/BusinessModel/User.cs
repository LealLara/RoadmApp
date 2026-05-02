using RoadmApp.Domain.Utils.Contants;

namespace RoadmApp.Domain.BusinessModel
{
    public class User
    {
        public int UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Nickname { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; }
        public DateTime Birthday { get; private set; } = DateTime.Today;
        public List<Contact> Contacts { get; private set; } = new List<Contact>();

        public User() { }
        public User(int userId, string nickname, string name, string passwordHash, DateTime birthday, List<Contact> contacts) : this()
        {
            UserId = userId;
            Name = name;
            Nickname = nickname;
            Name = name;
            PasswordHash = passwordHash;
            Birthday = birthday;
            Contacts = contacts;
        }
        public User(string name, string nickname, string passwordHash) : this()
        {
            Name = name;
            Nickname = nickname;
            PasswordHash = passwordHash; 
        }
        public User(string name, string nickname, string passwordHash, List<string> contacts) : this()
        {
            Name = name;
            Nickname = nickname;
            PasswordHash = passwordHash; 
            Contacts = contacts.Select(email => new Contact(email)).ToList();
        }
        public User(int userId, string name, string nickname,  DateTime birthday) : this()
        {
            UserId = userId;
            Name = name;
            Nickname = nickname;
            Name = name;
            Birthday = birthday;
        }
        public User(int userId, string name, string nickname,  DateTime birthday, string passwordHash) : this()
        {
            UserId = userId;
            Name = name;
            Nickname = nickname;
            Name = name;
            Birthday = birthday;
            PasswordHash = passwordHash;
        }
        public User(string nickname, string passwordHash) : this()
        {
            Nickname = nickname;
            PasswordHash = passwordHash;
        }
        public User(string name, DateTime birthday) : this()
        {
            Name = name;
            Birthday = birthday;
        }
        public User(int userId, string name) : this()
        {
            Name = name;
            UserId = userId;

        }
        public User(int userId, string nickname, List<Contact> contacts) : this()
        {
            UserId = userId;
            Nickname = nickname;
            Contacts = contacts;
        }
        public User(int userId, string nickname, Contact contacts) : this()
        {
            UserId = userId;
            Nickname = nickname;
            Contacts = new List<Contact> { contacts };
        }
        public string GenerateHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("A senha não pode ser nula ou vazia.", nameof(password));

            string? hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return hashedPassword;
        }
        public string SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("A senha não pode ser nula ou vazia.", nameof(password));

            PasswordHash = GenerateHash(password);
            return PasswordHash;
        }
        public string SetPatternPasswordResult()
        {
            return PasswordHash = PatternAccountConfig.PatternFirstRegister;
        }
        public List<Contact> SetContactResult(Contact contact)
        {
            Contacts = new List<Contact> { contact };
            return Contacts;
        }
        public User Transform(Register register)
        {
            return new()
            {
                Name = register.User.Name,
                Birthday = register.User.Birthday,
                Nickname = register.Access.Nickname,
                PasswordHash = SetPassword(register.Access.Password),
                Contacts = new List<Contact> { register.Contacts },
            };
        }
        public User Transform()
        {
            return new()
            {
                Name = Name,
                Birthday = Birthday
            };
        }
        public User ToBusiness(Register register)
        {
            return new()
            {
                Name = register.User.Name,
                Birthday = register.User.Birthday,
                Nickname = register.Access.Nickname,
                PasswordHash = SetPassword(register.Access.Password),
                Contacts = new List<Contact> { register.Contacts },
            };
        }
    }
}