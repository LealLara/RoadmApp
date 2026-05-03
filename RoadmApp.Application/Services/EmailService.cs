using RoadmApp.Application.IServices;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.IRepositories;
using RoadmApp.Domain.Utils.Contants;
using RoadmApp.Domain.Utils.Enums;
using RoadmApp.Domain.Utils.StringTools;
using RoadmApp.Domain.Utils.Templates;

namespace RoadmApp.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<List<EmailType>> GetEmailTyes()
        {
            List<EmailType> types = new();
            List<EEmailType> data = await _emailRepository.GetEmailTyes();

            if (data == null)
                return types;

            foreach (var item in data)
            {
                EmailType emailType = new()
                {
                    Id = (int)item,
                    Description = item.GetDescription()
                };
                types.Add(emailType);
            }
            return types;
        }

        public  async Task<string> BildEmailBody(EEmailType type)
        {
            switch (type)
            {
                case EEmailType.Welcome:
                    return EmailTemplates.GetTemplate(EEmailType.Welcome);
                case EEmailType.FirstRegister:
                    return EmailTemplates.GetTemplate(EEmailType.FirstRegister);
                case EEmailType.PasswordReset:
                    return EmailTemplates.GetTemplate(EEmailType.PasswordReset);
                case EEmailType.BloomingLove:
                    return EmailTemplates.GetTemplate(EEmailType.BloomingLove);
                default:
                    return string.Empty;
            } 
        }

        public async Task SendAsync(Email data)
        {
            EmailEntity emailBody = new();

            string head = ((EEmailType)data.EmailType).GetDescription();
            string text = EmailTemplates.GetTemplate((EEmailType)data.EmailType);

            emailBody = new(emailAddress: data.EmailAddress, header: head, emailBody: text, emailType: (EEmailType)data.EmailType);

            await _emailRepository.SendAsync(emailBody);
        }

        public async Task<Success> EmailAlreadyExists(Contact? existing)
        {
            Success successResult = new();

            if (existing is not null)
            {
                successResult = new()
                {
                    SuccessFlag = false,
                    Message = Messages.EmailAlreadyRegistered
                };
            }

            return successResult;
        }


    }
}