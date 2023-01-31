using Microsoft.EntityFrameworkCore;
using Swd.PlayCollector.Model;

namespace Swd.PlayCollector.Repository;

public class LocationRepository : GenericRepository<Location, PlayCollectorContext>, ILocationRepository
{
    
}