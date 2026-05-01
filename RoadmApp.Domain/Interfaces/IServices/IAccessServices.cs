using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface ICreateAccessUseCase
    {
        Task<Success> CreateAccess(Register data);
    }
}