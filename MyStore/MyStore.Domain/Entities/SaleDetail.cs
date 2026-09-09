using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.Entities
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        public virtual Sale Sale { get; set; }

        public virtual Product Product { get; set; }
    }
}
