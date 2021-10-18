using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.DTOs
{
    public class SaleStoreProductDto : BaseDto
    {
        public SaleDto Sale { get; set; }

        public StoreProductDto StoreProduct { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Id Venda: {Sale.Id} | Produto: {StoreProduct.Product.Name} | Quantidade: {Quantity}";
        }
    }
}