using RoadmApp.Domain.Entities;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface ILogRepository
    {
        Task<Log> AddLog(LogEntity log);

        Task<List<Log>> GetLogs();
    }
}