using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface ILogService
    {
        Task<Log> AddLog(Log log);

        Task<List<Log>> GetLogs();
    }
}