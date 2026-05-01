using RoadmApp.Domain.Entities;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByNicknameAsync(string email);
        Task<User?> AddAsync(UserEntity user);
        Task<User?> GetByIdAsync(int id);
    }
}