using System;
using System.Collections.Generic;

namespace Misbah_VisualProgramming_Project.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = "Walk-in Customer";
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Preparing"; // Preparing, Completed, Dispatched
        public decimal TotalAmount { get; set; }

        // Composition relationship: An order contains a collection of items
        public List<OrderDetail> OrderLines { get; set; } = new List<OrderDetail>();
    }
}