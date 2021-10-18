using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Entities
{
    /// <summary>
    /// This entity stores the information about a customer.
    /// </summary>
    public class SaleStoreProductEntity : Entity
    {
        /// <summary>
        /// The sale responsible for the bond.
        /// </summary>
        public SaleEntity Sale { get; set; }

        /// <summary>
        /// The item bought.
        /// </summary>
        public StoreProductEntity StoreProduct { get; set; }

        /// <summary>
        /// The quantity of items bought in the sale.
        /// </summary>
        public int Quantity { get; set; }
    }
}
