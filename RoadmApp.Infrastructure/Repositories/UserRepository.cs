using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Factories;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Models;
using RoadmApp.Infrastructure.Data;

namespace RoadmApp.Infrastructure.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetByNicknameAsync(string nick)
        {
            try
            {
                var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nick);
                return userEntity != null ? ModelFactory.CreateUserModel(userEntity) : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            try
            {
                var userEntity = await _context.Set<UserEntity>().FindAsync(id);
                return userEntity != null ? ModelFactory.CreateUserModel(userEntity) : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<UserModel?> AddAsync(UserEntity user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return ModelFactory.CreateUserModel(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}