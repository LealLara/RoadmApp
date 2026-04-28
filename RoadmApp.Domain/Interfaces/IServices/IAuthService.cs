namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface IAuthService
    { 
        Task<string> Login(string nick, string password);
    }
}