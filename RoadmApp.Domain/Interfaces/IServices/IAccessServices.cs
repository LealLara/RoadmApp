using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface IAccessService
    {
        Task<User> CreateAccess(Register data);
    }
}