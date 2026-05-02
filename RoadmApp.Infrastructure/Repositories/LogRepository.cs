using Microsoft.EntityFrameworkCore;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Factories;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Infrastructure.Data;
using RoadmApp.Domain.IRepositories;

namespace RoadmApp.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly AppDbContext _context;

        public LogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Log> AddLog(LogEntity log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
            return ModelFactory.CreateLogModel(log);
        }
        public async Task<List<Log>> GetLogs()
        {
            var logEntities = await _context.Logs.ToListAsync();
            return logEntities.Select(ModelFactory.CreateLogModel).ToList();
        }
    }
}