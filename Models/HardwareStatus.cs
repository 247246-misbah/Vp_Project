using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misbah_VisualProgramming_Project.Models
{
    [Table("hardwarestatus")]
    public class HardwareStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Is line ko check karein, hum explicitly column name mapping auto par chhor rahe hain
        public int Id { get; set; }

        [Column("MachineName")]
        public string MachineName { get; set; } = "Espresso Twin-X1";

        [Column("CurrentState")]
        public string CurrentState { get; set; } = "Idle";

        [Column("Temperature")]
        public double Temperature { get; set; } = 92.5;

        [Column("WaterLevel")]
        public int WaterLevel { get; set; } = 85;

        [Column("BeanWeight")]
        public int BeanWeight { get; set; } = 450;

        [Column("IsConnected")]
        public bool IsConnected { get; set; } = true;
    }
}