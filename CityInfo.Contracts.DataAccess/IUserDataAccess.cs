using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CityInfo.Contracts.Services.Entities;

namespace CityInfo.Contracts.DataAccess
{
    public interface IUserDataAccess
    {
        User Find(string username, string password);

        IEnumerable<User> List();

        IEnumerable<User> List(Expression<Func<User, bool>> predicate);

        void Add(User user);

        void Delete(User user);
    }
}