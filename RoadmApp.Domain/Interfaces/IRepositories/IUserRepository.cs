using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByNicknameAsync(string email);
        Task<User> AddAsync(User user);
        Task<User> GetByIdAsync(int id);
    }
}