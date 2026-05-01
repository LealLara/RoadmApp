using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface IPasswordResetRepository
    {
        Task CreateAsync(PasswordResetToken token);
        Task<PasswordResetToken?> GetByTokenAsync(string token);
        Task RemoveAsync(PasswordResetToken token);
    }
}