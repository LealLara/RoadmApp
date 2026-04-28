using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Models;
using RoadmApp.Domain.Utils.Enums;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface IEmailService
    {
        Task SendAsync(Email body);
        Task<List<EmailTypes>> GetEmailTyes();
    }
}