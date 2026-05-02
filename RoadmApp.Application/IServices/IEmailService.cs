using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Application.IServices
{
    public interface IEmailService
    {
        Task SendAsync(Email body);
        Task<List<EmailType>> GetEmailTyes();
    }
}