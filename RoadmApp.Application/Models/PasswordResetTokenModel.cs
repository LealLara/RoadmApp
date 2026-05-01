namespace RoadmApp.Application.Models
{
    public class PasswordResetTokenModel
    {
        public int Id { get; private set; }
        public string Token { get; private set; }
        public int UserId { get; private set; }
        public DateTime Expiration { get; private set; }
        
        public PasswordResetTokenModel(int id, int userId, string token,  DateTime expiration)
        {
            Id = id;
            UserId = userId;
            Token = token;
            Expiration = expiration;
        }
        public PasswordResetTokenModel(int userId, string token,  DateTime expiration)
        { 
            UserId = userId;
            Token = token;
            Expiration = expiration;
        }
    }
}