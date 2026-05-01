using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Interfaces.IServices
{
    public interface IEmailService
    {
        Task SendAsync(Email body);
        Task<List<EmailType>> GetEmailTyes();
    }
}