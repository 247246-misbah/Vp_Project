namespace Misbah_VisualProgramming_Project.Data.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Navigation properties to retain foreign references safely
        public MenuItem? MenuItem { get; set; }
    }
}