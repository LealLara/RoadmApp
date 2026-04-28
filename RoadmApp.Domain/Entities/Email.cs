using RoadmApp.Domain.Utils.Enums;

namespace RoadmApp.Domain.Entities
{
    public class Email
    {
        public int EmailId { get; private set; }
        public string EmailAddress { get; private set; } = string.Empty;
        public string Header { get; private set; } = string.Empty;
        public string EmailBody { get; private set; } = string.Empty;
        public int EmailType { get; private set; }

        public Email() { }
         
        public Email(string emailAddress, string header, string emailBody, EEmailType emailType)
        {
            EmailAddress = emailAddress;
            Header = header;
            EmailBody = emailBody;
            EmailType = (int)emailType;
        }
        public Email(string emailAddress, EEmailType emailType)
        {
            EmailAddress = emailAddress;  
            EmailType = (int)emailType;
        }
    }
}