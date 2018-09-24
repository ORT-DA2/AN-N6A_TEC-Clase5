using CityInfo.Contracts.Services.Entities;

namespace CityInfo.Contracts.DataAccess
{
    public interface ISessionRepository
    {
        bool IsValidToken(string token);

        bool HasLevel(string token, string role);
    }
}