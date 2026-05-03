using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Utils.Enums;

namespace RoadmApp.Application.IServices
{
    public interface IEmailService
    {
        Task SendAsync(Email body);
        Task<List<EmailType>> GetEmailTyes();
        Task<string> BildEmailBody(EEmailType type);
        Task<Success> EmailAlreadyExists(Contact? existing);

    }
}