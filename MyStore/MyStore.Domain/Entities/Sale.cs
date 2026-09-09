using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual User User { get; set; } = null!;

        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
