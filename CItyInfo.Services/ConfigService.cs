using CityInfo.Contracts.Services;

namespace CItyInfo.Services
{
    public class ConfigService : IReadConfig
    {
        public string GetDevName()
        {
            /*var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();*/

            return null;
        }
    }
}