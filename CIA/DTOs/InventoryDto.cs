using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DTOs
{
    public class InventoryDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Preco: {Price} Quantidade: {Quantity}";
        }

    }
}