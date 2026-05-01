namespace RoadmApp.Application.Models
{
    public class UserModel
    {
        public int UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Nickname { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; }
        public DateTime Birthday { get; private set; } = DateTime.Today;
        public ICollection<ContactModel> Contacts { get; private set; } = new List<ContactModel>();

        public UserModel() { }
        public UserModel(int userId, string nickname, string name, string passwordHash, DateTime birthday, ICollection<ContactModel> contacts) : this()
        {
            UserId = userId;
            Name = name;
            Nickname = nickname;
            Name = name;
            PasswordHash = passwordHash;
            Birthday = birthday;
            Contacts = contacts;
        }
        public UserModel(string name, string nickname, string passwordHash) : this()
        {
            Name = name;
            Nickname = nickname;
            PasswordHash = passwordHash; 
        }
        public UserModel(string name, string nickname, string passwordHash, List<string> contacts) : this()
        {
            Name = name;
            Nickname = nickname;
            PasswordHash = passwordHash; 
            Contacts = contacts.Select(email => new ContactModel(email)).ToList();
        }
        public UserModel(int userId, string name, string nickname,  DateTime birthday) : this()
        {
            UserId = userId;
            Name = name;
            Nickname = nickname;
            Name = name;
            Birthday = birthday;
        }
        public UserModel(string nickname, string passwordHash) : this()
        {
            Nickname = nickname;
            PasswordHash = passwordHash;
        }
        public UserModel(string name, DateTime birthday) : this()
        {
            Name = name;
            Birthday = birthday;
        }
        public UserModel(int userId, string name) : this()
        {
            Name = name;
            UserId = userId;

        }
        public UserModel(int userId, string nickname, List<ContactModel> contacts) : this()
        {
            UserId = userId;
            Nickname = nickname;
            Contacts = contacts;
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
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));

            PasswordHash = GenerateHash(password);
            return PasswordHash;
        }
        public UserModel Transform(RegisterModel register)
        {
            return new()
            {
                Name = register.User.Name,
                Birthday = register.User.Birthday,
                Nickname = register.Access.Nickname,
                PasswordHash = SetPassword(register.Access.Password),
                Contacts = register.Contacts,
            };
        }
        public UserModel TransformResult()
        {
            return new()
            {
                Name = Name,
                Birthday = Birthday
            };
        }
    }
}