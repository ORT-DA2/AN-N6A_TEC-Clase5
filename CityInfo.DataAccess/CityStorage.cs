using System.Collections.Generic;
using System.Linq;
using CityInfo.Contracts.DataAccess;
using CityInfo.Contracts.Services.Entities;

namespace CityInfo.DataAccess
{
    public class CityStorage : ICityDataAccess
    {
        private readonly CityInfoContext context;

        public CityStorage(CityInfoContext context)
        {
            this.context = context;
        }
        public City Find(int cityId)
        {
            return this.context.Cities.FirstOrDefault(c => c.Id == cityId);
        }

        public IEnumerable<City> List()
        {
            return this.context.Cities;
        }

        public void Add(City city)
        {
            this.context.Cities.Add(city);

            this.context.SaveChanges();
        }
    }
}
