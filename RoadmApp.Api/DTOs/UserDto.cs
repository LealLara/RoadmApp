using RoadmApp.Domain.Models;

namespace RoadmApp.Api.DTOs
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.Today;

        public UserModel Transform()
        {
            return new(
                name: Name,
                birthday: Birthday
            );
        }
    }
}