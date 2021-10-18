using CIA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Repositories
{
    public class DbInventoryRepository : DbRepository<StoreProductEntity>, IInventoryRepository
    {
        public DbInventoryRepository(ApplicationDbContext context)
            : base(context)
        {

        }
}
}
