using RoadmApp.Domain.Entities;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByNicknameAsync(string nickname);
        Task<User?> AddAsync(UserEntity user);
        Task<User?> GetByIdAsync(int id);
        Task<string?> GetHash(string nickname);
        Task<List<User>> GetAllAsync();
        Task<User?> UpdatePasswordAsync(UserEntity? entity);


       // Task<User?> UpdateAsync(UserEntity user);
    }
}