using CIA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Repositories
{
    public class DbSaleRepository : DbRepository<SaleEntity>, ISaleRepository
    {
        public DbSaleRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public int Add(SaleEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
    }
}
