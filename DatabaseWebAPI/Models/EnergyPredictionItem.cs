using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseWebAPI.Models
{
    public class EnergyPredictionItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public float EnergyPrediction { get; set; }

        [Required]
        [MaxLength(10)]
        public string EnergyPredictionUoM { get; set; } = "kWh";

        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
