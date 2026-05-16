using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misbah_VisualProgramming_Project.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("id")] // Maps uppercase 'Id' property to your database lowercase 'id' column
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; } = string.Empty;

        [Column("Price")]
        public decimal Price { get; set; }

        [Required]
        [Column("Category")]
        public string Category { get; set; } = string.Empty;

        [Column("IsAvailable")]
        public bool IsAvailable { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }

        [Column("ImageUrl")]
        public string ImageUrl { get; set; } = "https://images.unsplash.com/photo-1514432324607-a09d9b4aefdd?q=80&w=300";
    }
}