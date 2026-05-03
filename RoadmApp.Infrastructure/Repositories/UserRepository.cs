using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Factories;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Infrastructure.Data;
using RoadmApp.Domain.IRepositories;

namespace RoadmApp.Infrastructure.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByNicknameAsync(string nick)
        {
            try
            {
                var userEntity = await _context.Users.Include(u => u.Contacts).FirstOrDefaultAsync(u => u.Nickname == nick);
                return userEntity != null ? ModelFactory.CreateUserBusiness(userEntity) : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<string?> GetHash(string nick)
        {
            try
            {
                UserEntity userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nick);
                return userEntity?.PasswordHash;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                var userEntity = await _context.Set<UserEntity>().Include(u => u.Contacts).FirstOrDefaultAsync(u => u.UserId == id);
                return userEntity != null ? ModelFactory.CreateUserBusiness(userEntity) : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task< List<User>> GetAllAsync()
        {
            try
            {
                var userEntities = await _context.Users.Include(u => u.Contacts).ToListAsync();
                return userEntities.Select(ModelFactory.CreateUserBusiness).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<User?> AddAsync(UserEntity user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return ModelFactory.CreateUserBusiness(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}