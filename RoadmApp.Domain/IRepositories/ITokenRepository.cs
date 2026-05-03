namespace RoadmApp.Domain.IRepositories
{
    public interface ITokenRepository
    {
        Task<string> GenerateToken(string hash);
    }
}