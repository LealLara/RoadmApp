using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Utils.Enums;

namespace RoadmApp.Domain.Interfaces.IRepositories
{
    public interface IEmailRepository
    {
        Task SendAsync(EmailEntity body);
        Task<List<EEmailType>> GetEmailTyes();
    }
}