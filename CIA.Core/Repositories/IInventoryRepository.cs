using CIA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Repositories
{
    /// <summary>
    /// Stores records.
    /// </summary>
    public interface IInventoryRepository : IRepository<StoreProductEntity>
    {
    }
}
