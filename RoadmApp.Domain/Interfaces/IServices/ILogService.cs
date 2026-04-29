using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface ILogService
    {
        Task<LogModel> AddLog(LogEntity log);

        Task<List<LogModel>> GetLogs();
    }
}