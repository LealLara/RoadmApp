using RoadmApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace RoadmApp.Domain.Entities
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Nickname { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; }
        public DateTime Birthday { get; private set; } = DateTime.Today;
        public ICollection<ContactEntity> Contacts { get; private set; } = new List<ContactEntity>();

        public UserEntity() { }
        public UserEntity(string username, string nickname, string passwordHash, List<string> contacts) : this()
        {
            Name = username;
            Nickname = nickname;
            PasswordHash = passwordHash;
            Contacts = contacts.Select(email => new ContactEntity(email)).ToList();
        }
        public UserEntity(string username, string nickname, string passwordHash, DateTime birthday) : this()
        {
            Name = username;
            Nickname = nickname;
            PasswordHash = passwordHash;
            Birthday = birthday;
        }
        public UserEntity(string nickname, string passwordHash)
        {
            Nickname = nickname;
            PasswordHash = passwordHash;
        }
        public UserEntity(string nickname, string passwordHash, List<string> contacts)
        {
            Nickname = nickname;
            PasswordHash = passwordHash;
            Contacts = contacts.Select(email => new ContactEntity(email)).ToList();
        }
        public UserEntity(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
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

        public UserEntity TransformResult()
        {
            return new()
            {
                Name = Name,
                Birthday = Birthday
            };
        }

        public UserEntity TransformToUserEntity(RegisterModel register)
        {
            return new(
                username: register.User.Name,
                nickname: register.Access.Nickname,
                passwordHash: register.Access.Password,
                birthday: register.User.Birthday
            );
        }
    }
}