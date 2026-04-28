using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Interfaces.IServices;

namespace RoadmApp.Domain.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public Task<Log> AddLog(Log log)
        {
            return _logRepository.AddLog(log);
        }

        public Task<List<Log>> GetLogs()
        {
            return _logRepository.GetLogs();
        }
    }
}