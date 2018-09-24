using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CityInfo.Contracts.Services.Entities;

namespace CityInfo.Contracts.DataAccess
{
    public interface ICityDataAccess
    {
        City Find(int cityId);

        IEnumerable<City> List();

        void Add(City city);

    }
}