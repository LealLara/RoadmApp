using RoadmApp.Application.Responses;

namespace RoadmApp.Application.IServices
{
    public interface ICreateAccessUseCase
    {
        Task<SuccessModel> CreateAccess(RegisterModel data);
    }
}