using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Models;
using RoadmApp.Infrastructure.Data;

namespace RoadmApp.Infrastructure.Repositories
{
    public class PasswordResetRepository : IPasswordResetRepository
    {
        private readonly AppDbContext _context;

        public PasswordResetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PasswordResetTokenModel token)
        {
            await _context.Set<PasswordResetTokenModel>().AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordResetTokenModel?> GetByTokenAsync(string token)
        {
            return await _context.Set<PasswordResetTokenModel>()
                .FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task RemoveAsync(PasswordResetTokenModel token)
        {
            _context.Remove(token);
            await _context.SaveChangesAsync();
        }
    }
}