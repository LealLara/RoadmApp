using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<UserModel?> GetByNicknameAsync(string email);
        Task<UserModel?> AddAsync(UserEntity user);
        Task<UserModel?> GetByIdAsync(int id);
    }
}