using System;
using System.Linq;
using CityInfo.Contracts.DataAccess;

namespace CityInfo.DataAccess
{
    public class SessionStorage : ISessionRepository
    {
        private readonly CityInfoContext context;

        public SessionStorage(CityInfoContext context)
        {
            this.context = context;
        }

        public bool IsValidToken(string token)
        {
            Guid parsedToken;

            if (string.IsNullOrEmpty(token)) return false;

            bool isValid = Guid.TryParse(token, out parsedToken);
            return isValid && this.context.Sessions.Any(s => s.Id == parsedToken);
        }

        public bool HasLevel(string token, string role)
        {
            var  guid = new Guid(token); 
            return this.context.Sessions.Any(s => s.Id == guid &&
            s.Role.Equals(role, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
