using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CityInfo.Contracts.DataAccess;
using CityInfo.Contracts.Services.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.DataAccess
{
    public class UserStorage : IUserDataAccess
    {
        public readonly CityInfoContext context;

        public UserStorage(CityInfoContext context)
        {
            this.context = context;
        }

        public User Find(string username, string password)
        {
            return this.context.Users.Include(s => s.Session).FirstOrDefault(u => u.UserName.Equals(username,StringComparison.InvariantCultureIgnoreCase) &&
                                                          u.Password.Equals(password));
        }

        public IEnumerable<User> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> List(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(User user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }
    }
}
