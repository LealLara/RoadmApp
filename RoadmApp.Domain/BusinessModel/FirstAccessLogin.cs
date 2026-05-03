namespace RoadmApp.Domain.BusinessModel
{
    public class FirstAccessLogin
    {
        public string Nickname { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}