using Microsoft.EntityFrameworkCore;
using Swd.PlayCollector.Model;

namespace Swd.PlayCollector.Repository;

public class CollectionItemRepository : GenericRepository<CollectionItem, PlayCollectorContext>, ICollectionItemRepository
{
    
}