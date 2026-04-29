using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface IEmailService
    {
        Task SendAsync(EmailModel body);
        Task<List<EmailTypeModel>> GetEmailTyes();
    }
}