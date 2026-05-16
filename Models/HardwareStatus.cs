using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misbah_VisualProgramming_Project.Models
{
    [Table("hardwarestatus")]
    public class HardwareStatus
    {
        // Agar aapke database table mein column ka naam capital "Id" hai, toh yahan "Id" likhein
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("MachineName")]
        public string MachineName { get; set; } = "Espresso Twin-X1";

        [Column("CurrentState")]
        public string CurrentState { get; set; } = "Idle";

        [Column("Temperature")]
        public double Temperature { get; set; }

        [Column("WaterLevel")]
        public int WaterLevel { get; set; }

        [Column("BeanWeight")]
        public int BeanWeight { get; set; }

        [Column("IsConnected")]
        public bool IsConnected { get; set; }
    }
}