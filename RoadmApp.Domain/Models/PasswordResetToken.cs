namespace RoadmApp.Domain.Models
{
    public class PasswordResetToken
    {
        public int Id { get; private set; }
        public string Token { get; private set; }
        public int UserId { get; private set; }
        public DateTime Expiration { get; private set; }
        
        public PasswordResetToken(int id, int userId, string token,  DateTime expiration)
        {
            Id = id;
            UserId = userId;
            Token = token;
            Expiration = expiration;
        }
        public PasswordResetToken(int userId, string token,  DateTime expiration)
        { 
            UserId = userId;
            Token = token;
            Expiration = expiration;
        }
    }
}