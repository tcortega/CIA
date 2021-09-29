using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Entities
{
    /// <summary>
    /// This entity stores the information about a product.
    /// </summary>
    public class ProductEntity : Entity
    {
        /// <summary>
        /// The name of the product.
        /// </summary>
        public string Name { get; set; }
    }
}
