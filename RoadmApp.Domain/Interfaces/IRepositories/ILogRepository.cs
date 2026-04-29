using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface ILogRepository
    {
        Task<LogModel> AddLog(LogEntity log);

        Task<List<LogModel>> GetLogs();
    }
}