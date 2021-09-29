using CIA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Repositories
{
    public class DbStoreRepository : DbRepository<StoreEntity>, IStoreRepository
    {
        public DbStoreRepository(ApplicationDbContext context)
            : base(context)
        {

        }
}
}
