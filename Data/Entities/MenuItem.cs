using System.ComponentModel.DataAnnotations;

namespace Misbah_VisualProgramming_Project.Data.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Item title is mandatory")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(1, 10000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public string Category { get; set; } = "Hot Coffee Base";
        public int StockLevel { get; set; } = 50;
        public bool IsAvailable => StockLevel > 0;
    }
}
