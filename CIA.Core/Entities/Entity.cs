using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Entities
{
    /// <summary>
    /// This is the base class for an entity that is saved to a database.
    /// </summary>
    public class Entity
    { 
        public int Id { get; set; }
    }
}
