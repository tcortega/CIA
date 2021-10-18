using CIA.Core.Entities;

namespace CIA.DTOs
{
    public class SaleDto : BaseDto
    {
        public CustomerDto Customer { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual int Quantity { get; set; }

        public SaleStatus Status { get; set; }

        public override string ToString()
            => $"Id: {Id} | Cliente: {Customer.Name} | Preço Total: {TotalPrice} | Status: {GetStatusFormatted()}";

        private string GetStatusFormatted()
            => Status switch
            {
                SaleStatus.Pending => "Pendente",
                SaleStatus.Confirmed => "Confirmado",
                SaleStatus.Cancelled => "Cancelado",
                _ => "Desconhecido"
            };
    }
}