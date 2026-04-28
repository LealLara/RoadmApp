namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface ITokenRepository
    {
        Task<string> GenerateToken(int userId);
    }
}