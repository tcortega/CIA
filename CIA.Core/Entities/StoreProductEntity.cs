using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Entities
{
    /// <summary>
    /// This entity stores the information about which and how many
    /// products a store have, and what is its price.
    /// </summary>
    public class StoreProductEntity : Entity
    {
        /// <summary>
        /// The store that owns this product.
        /// </summary>
        public StoreEntity Store { get; set; }
        /// <summary>
        /// The product which the store owns.
        /// </summary>
        public ProductEntity Product { get; set; }
        /// <summary>
        /// The price of the product in the given store.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// The quantity of the products in the given store.
        /// </summary>
        public int Quantity { get; set; }
    }
}
