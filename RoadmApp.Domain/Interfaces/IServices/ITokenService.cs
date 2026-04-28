namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface ITokenService
    {
        Task<string> GenerateToken(int userId);
    }
}