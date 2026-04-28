using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IRepositories;
using RoadmApp.Domain.Utils.Contants;
using RoadmApp.Domain.Utils.Enums;
using RoadmApp.Domain.Utils.StringTools;
using System.Net;
using System.Net.Mail;

namespace RoadmApp.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public async Task SendAsync(Email body) 
        {

            string emailSender = EEmailSender.RoadmApp.GetDescription(); 
            string password = EmailSenderPassword.RoadmAppPassword; 


            SmtpClient smtp = new (EmailConfiguration.SmtpConfigurationHost, EmailConfiguration.SmtpConfigurationPort)
            {
                Credentials = new NetworkCredential(
                   emailSender,
                   password
                ),
                EnableSsl = true
            };

            string title = EAppTitle.RoadmAPP.GetDescription();

            var mail = new MailMessage
            {
                From = new MailAddress(emailSender, title),
                Subject = body.Header,
                Body = body.EmailBody,
                IsBodyHtml = true
            };

            mail.To.Add(body.EmailAddress);
            await smtp.SendMailAsync(mail);
        }

        public async Task<List<EEmailType>> GetEmailTyes()
        {
            return await Task.FromResult(Enum.GetValues(typeof(EEmailType)).Cast<EEmailType>().ToList());
             
        }   
    }
}