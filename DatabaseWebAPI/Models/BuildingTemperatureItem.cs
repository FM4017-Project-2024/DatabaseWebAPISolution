using System.ComponentModel.DataAnnotations;

namespace DatabaseWebAPI.Models
{
    public class BuildingTemperatureItem
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public float Temp1 { get; set; }
        [Required]
        public float Temp2 { get; set; }
        [Required]
        public float Temp3 { get; set; }
        [Required]
        public float Temp4 { get; set; }
        [Required]
        public float Temp5 { get; set; }
        [Required]
        [MaxLength(10)]
        public string? TempUoM { get; set; } = "°C";
        [Required]
        public DateTime? TempDateTime { get; set; } = DateTime.Now;
    }
}
