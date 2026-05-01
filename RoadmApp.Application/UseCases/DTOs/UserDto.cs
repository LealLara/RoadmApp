using RoadmApp.Application.Models;
using RoadmApp.Domain.BusinessModel; 

namespace RoadmApp.Application.UseCases.Access.CreateAccess
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.Today;

        public User ToBusiness()
        {
            return new(
                name: Name,
                birthday: Birthday
            );
        }
        public UserModel Transform()
        {
            return new(
                name: Name,
                birthday: Birthday
            );
        }
    }
}