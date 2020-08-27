using Spifield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models.Repositories
{
    public interface ILocationRepository
    {
        List<Location> getLocations();
        List<Monster> getMonstersFromLocation(int locationID);
    }
}
