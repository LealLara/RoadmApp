namespace RoadmApp.Application.AplicationModels
{
    public class LoginModel
    {
        public string Nickname { get; set; }
        public string Password { get; set; }

        public LoginModel() { }
        public LoginModel(string nikName, string password)
        {
            Nickname = nikName;
            Password = password;
        }
    }
}