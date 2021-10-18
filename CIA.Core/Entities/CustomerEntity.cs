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
    public class CustomerEntity : Entity
    {
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The address of the customer.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The birthdate of the customer.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// The gender of the customer.
        /// </summary>
        public string Gender { get; set; }
    }
}
