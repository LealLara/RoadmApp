using RoadmApp.Application.Models;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Interfaces.IServices;
using RoadmApp.Domain.BusinessModel;
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

            if(data == null)
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

        public async Task SendAsync(Email data)
        {
            EmailEntity emailBody = new();

            string head = ((EEmailType)data.EmailType).GetDescription();
            string text = EmailTemplates.GetTemplate((EEmailType)data.EmailType);

            emailBody = new(emailAddress: data.EmailAddress, header: head, emailBody: text, emailType: (EEmailType)data.EmailType);

            await _emailRepository.SendAsync(emailBody);
        }
    }
}