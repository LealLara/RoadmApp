namespace RoadmApp.Application.IServices
{
    public interface ITokenService
    {
        Task<string> GenerateToken(int userId);
    }
}