using RoadmApp.Domain.Entities;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface ILogService
    {
        Task<Log> AddLog(LogEntity log);

        Task<List<Log>> GetLogs();
    }
}