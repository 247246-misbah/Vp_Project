using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misbah_VisualProgramming_Project.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } // Parent Relationship

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}