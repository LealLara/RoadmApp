using RoadmApp.Application.AplicationModels;
using RoadmApp.Application.Responses;

namespace RoadmApp.Application.IServices
{
    public interface IFirstAccessUseCase
    {
        Task<SuccessModel> FirstAccess(FirstAccessLoginModel login);
    }
}