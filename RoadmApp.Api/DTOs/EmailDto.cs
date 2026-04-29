using RoadmApp.Domain.Models;
using RoadmApp.Domain.Utils.Enums;

namespace RoadmApp.Domain.Services
{
    public class EmailDto
    {
        public string EmailAddress { get; set; }
        public EEmailType EmailType { get; set; }


        public EmailModel Transform()
        {
            return new(
                emailAddress: EmailAddress,
                emailType: EmailType
            );
        }
    }
}