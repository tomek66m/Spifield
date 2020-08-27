using Spifield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _appDbContext;

        public LocationRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }
        public List<Location> getLocations()
        {
            List<Location> result = new List<Location>();

            result = _appDbContext.Locations.ToList();

            return result;


        }

        public List<Monster> getMonstersFromLocation(int locationID)
        {
            List<Monster> result = new List<Monster>();

            result = _appDbContext.Monsters.Where(a => a.LocationID == locationID).ToList();

            return result;
        }
    }
}
