using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface IPasswordResetRepository
    {
        Task CreateAsync(PasswordResetTokenModel token);
        Task<PasswordResetTokenModel?> GetByTokenAsync(string token);
        Task RemoveAsync(PasswordResetTokenModel token);
    }
}