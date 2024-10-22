using System.ComponentModel.DataAnnotations;

namespace DatabaseWebAPI.Models
{
    public class BuildingEnergyMeterItem
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public float EnergyMeter1 { get; set; }
        [Required]
        [MaxLength(10)]
        public string? EnergyMeterUoM { get; set; } = "kWh";
        [Required]
        public DateTime EnergyMeterDateTime { get; set; } = DateTime.Now;
    }
}
