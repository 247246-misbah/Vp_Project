using System.ComponentModel.DataAnnotations;

namespace Misbah_VisualProgramming_Project.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}