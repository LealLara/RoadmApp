using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Application.IServices
{
    public interface IAuthService
    { 
        Task<Success> Login(string nick, string password);
    }
}