namespace RoadmApp.Domain.IRepositories
{
    public interface ITokenRepository
    {
        Task<string> GenerateToken(int userId);
    }
}