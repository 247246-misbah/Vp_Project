using System.ComponentModel.DataAnnotations;

namespace Misbah_VisualProgramming_Project.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";

        // UML Composition & Object Collection Mapping
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
