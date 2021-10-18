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
    public class SaleEntity : Entity
    {
        /// <summary>
        /// The customer that made the sale.
        /// </summary>
        public CustomerEntity Customer { get; set; }

        /// <summary>
        /// The total price of the purchase.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// The status of the sale.
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
