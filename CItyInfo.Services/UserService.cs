using CityInfo.Contracts.DataAccess;
using CityInfo.Contracts.Services;
using CityInfo.Contracts.Services.Entities;

namespace CItyInfo.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess userDataAccess;

        public UserService(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }


        public void Add(User user)
        {
            this.userDataAccess.Add(user);
        }

        public Session Login(string username, string password)
        {
            var user = this.userDataAccess.Find(username, password);
            return user?.Session;
        }
    }
}
