using RoadmApp.Application.Models;
using RoadmApp.Domain.BusinessModel;
using RoadmApp.Domain.Utils.Enums;

namespace RoadmApp.Application.UseCases.Access.CreateAccess
{
    public class EmailDto
    {
        public string EmailAddress { get; set; }
        public EEmailType EmailType { get; set; }


        public EmailModel ToBusiness() 
        {
            return new(
                emailAddress: EmailAddress,
                emailType: EmailType
            );
        }
        public Email Transform()
        {
            return new(
                emailAddress: EmailAddress,
                emailType: EmailType
            );
        }
    }
}