using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Misbah_VisualProgramming_Project.Models
{
    [Table("hardwarestatus")]
    public class HardwareStatus
    {
        [Key]
        [Column("machineid")]
        public int MachineId { get; set; }

        [Column("machinename")]
        public string MachineName { get; set; } = "Espresso Twin-X1";

        [Column("currentstate")]
        public string CurrentState { get; set; } = "Idle";

        [Column("temperature")]
        public double Temperature { get; set; }

        [Column("waterlevel")]
        public int WaterLevel { get; set; }

        [Column("beanweight")]
        public int BeanWeight { get; set; }

        [Column("isconnected")]
        public bool IsConnected { get; set; }
    }
}