
using CityInfo.Contracts.Services.Entities;

namespace CityInfo.Contracts.Services
{
    public interface IUserService
    {
        void Add(User user);

        Session Login(string username, string password);
    }
}