using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface IAccessService
    {
        Task<SuccessModel> CreateAccess(RegisterModel data);
    }
}