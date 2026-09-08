using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyStore.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public required string SKU { get; set; }

        [Required]
        public required string Name { get; set; } = String.Empty;

        public int Stock { get; set;}

        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }

        public string Sourceimage { get; set; }=string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
