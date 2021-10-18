using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DTOs
{
    public class StoreProductDto : BaseDto
    {
        public StoreDto Store { get; set; }

        public ProductDto Product { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Produto: {Product.Name} | Preço: {Price} | Quantidade Disponível: {Quantity}";
        }

    }
}