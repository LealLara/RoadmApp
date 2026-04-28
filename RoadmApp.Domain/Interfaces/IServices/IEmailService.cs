using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface IEmailService
    {
        Task SendAsync(Email body);
    }
}