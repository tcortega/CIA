using CIA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CIA.Core
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// The <see cref="DbContext"/> for the CIA core domain.
        /// </summary>
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<StoreEntity> Stores { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<StoreProductEntity> StoreProducts { get; set; }
    }
}
