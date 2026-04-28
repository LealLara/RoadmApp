using RoadmApp.Domain.Entities;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface IEmailRepository
    {
        Task SendAsync(Email body);

    }
}