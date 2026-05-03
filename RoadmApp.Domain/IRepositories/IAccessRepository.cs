using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.IRepositories
{
    public interface IAccessRepository
    {
        Task<Access> AddAsync(AccessEntity accessEntity);
    }
}