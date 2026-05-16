using System.ComponentModel.DataAnnotations;

namespace Misbah_VisualProgramming_Project.Models
{
    // UML Requirement: Base Class with virtual method
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }
        [Required]
        public string MachineName { get; set; }
        public bool IsConnected { get; set; } = true;
        public string CurrentState { get; set; } = "Idle";

        // Virtual method for Polymorphism criteria
        public virtual string GetEngineReport()
        {
            return "Core machine systems functional.";
        }
    }

    // UML Requirement: Derived Class Specialization
    public class HardwareStatus : Machine
    {
        public int WaterLevel { get; set; } = 100;
        public int BeanWeight { get; set; } = 1000;
        public decimal Temperature { get; set; } = 25.0m;

        // Polymorphic Override
        public override string GetEngineReport()
        {
            return $"[Digital Twin Dynamic State] Temp: {Temperature}°C | Water: {WaterLevel}% | Beans: {BeanWeight}g";
        }
    }
}