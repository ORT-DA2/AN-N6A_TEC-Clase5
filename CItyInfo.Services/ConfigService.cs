using CityInfo.Contracts.Services;
using Microsoft.Extensions.Configuration;

namespace CItyInfo.Services
{
    public class ConfigService : IReadConfig
    {
        public string GetDevName()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");

            var config = configurationBuilder.Build();

            return config["developer"];
        }
    }
}