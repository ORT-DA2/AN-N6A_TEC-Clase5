using System.Collections.Generic;
using CityInfo.Contracts.Services.Entities;

namespace CityInfo.Contracts.Services
{
    public interface ICityService
    {
        City GetCity(int id);

        IEnumerable<City> GetCities(string name);
    }
}