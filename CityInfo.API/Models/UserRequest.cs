
using CityInfo.Contracts.Services.Entities;

namespace CityInfo.API.Models
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User TransformToEntity()
        {
            return new User
            {
                Name = this.Name,
                UserName = this.UserName,
                Password = this.Password,
                Session = new Session() {Role = this.Role }
            };
        }
    }
}
