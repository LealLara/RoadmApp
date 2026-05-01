using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.BusinessModel;
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

        public async Task CreateAsync(PasswordResetToken token)
        {
            await _context.Set<PasswordResetToken>().AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordResetToken?> GetByTokenAsync(string token)
        {
            return await _context.Set<PasswordResetToken>()
                .FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task RemoveAsync(PasswordResetToken token)
        {
            _context.Remove(token);
            await _context.SaveChangesAsync();
        }
    }
}