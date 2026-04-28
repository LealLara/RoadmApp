using System.ComponentModel;

namespace RoadmApp.Domain.Utils.Enums
{
    public enum EEmailType
    {
        [Description("Welcome to RoadmAPP 🐰")]
        Welcome = 1,
        [Description("First Register")]
        FirstRegister = 2,
        [Description("Password Reset")]
        PasswordReset = 3,
        [Description("Poesia de amor")]
        BloomingLove = 4,
    }
}