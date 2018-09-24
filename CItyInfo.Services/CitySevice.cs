using System;
using System.Collections.Generic;
using System.Linq;
using CityInfo.Contracts.DataAccess;
using CityInfo.Contracts.Services;
using CityInfo.Contracts.Services.Entities;

namespace CItyInfo.Services
{
    public class CitySevice : ICityService
    {
        private readonly ICityDataAccess storage;

        public CitySevice(ICityDataAccess storage)
        {
            this.storage = storage;
        }

        public City GetCity(int id)
        {
            return this.storage.Find(id);
        }

        public IEnumerable<City> GetCities(string name)
        {
            var cities = this.storage.List();

            return !string.IsNullOrEmpty(name) ?
                cities.Where(city => city.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)) :
                cities;
        }
    }
}
