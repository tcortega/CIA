using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Nome: {Name} ";
        }

    }
}
