using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface IPasswordResetRepository
    {
        Task CreateAsync(PasswordResetToken token);
        Task<PasswordResetToken?> GetByTokenAsync(string token);
        Task RemoveAsync(PasswordResetToken token);
    }
}