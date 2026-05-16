using System;

namespace Misbah_VisualProgramming_Project.Data.Entities
{
    // Base class supporting OOP structure for physical cafe appliances
    public class HardwareSensor
    {
        public int Id { get; set; }
        public string MachineName { get; set; } = "Espresso Station #1";
        public double Temperature { get; set; } = 93.4;
        public int StatusBitmask { get; set; } = 1; // Used for binary register math simulation

        // Virtual method to satisfy UML architecture override goals
        public virtual string GetTelemetrySummary()
        {
            return $"Machine: {MachineName} | Temp: {Temperature}°C | Bitmask: {StatusBitmask}";
        }
    }

    // Derived class specialization required by project specifications
    public class AdvancedSmartSensor : HardwareSensor
    {
        public string FirmwareVersion { get; set; } = "v3.2.1";

        // Polymorphic method override
        public override string GetTelemetrySummary()
        {
            return $"{base.GetTelemetrySummary()} | Firmware: {FirmwareVersion}";
        }
    }
}