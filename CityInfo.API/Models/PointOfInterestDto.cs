
using CityInfo.Contracts.Services.Entities;

namespace CityInfo.API.Models
{
    public class PointOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public PointOfInterest ToEntity()
        {
            return new PointOfInterest()
            {
                Name = Name,
                Description = Description
            };
        }
    }
}
