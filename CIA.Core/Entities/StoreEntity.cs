using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Entities
{
    /// <summary>
    /// This entity stores the information about a store.
    /// </summary>
    public class StoreEntity : Entity
    {
        /// <summary>
        /// The name of the store.
        /// </summary>
        public string Name { get; set; }
    }
}
