using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Application.AplicationModels
{
    public class FirstAccessLoginModel
    {
        public string Nickname { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmNewPassword { get; set; } = string.Empty;
         
        public FirstAccessLogin ToBusiness()
        {
            return new()
            {
                Nickname = Nickname,
                NewPassword = NewPassword,
                ConfirmNewPassword = ConfirmNewPassword
            };
        }
    }
}