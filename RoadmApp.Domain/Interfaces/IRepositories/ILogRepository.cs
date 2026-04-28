using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface ILogRepository
    {
        Task<Log> AddLog(Log log);   
    }
}