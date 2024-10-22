using System.ComponentModel.DataAnnotations;

namespace DatabaseWebAPI.Models
{
    public class BuildingRelativeHumidityItem
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public float RelHumidity1 { get; set; }
        [Required]
        public float RelHumidity2 { get; set; }
        [Required]
        public float RelHumidity3 { get; set; }
        [Required]
        public float RelHumidity4 { get; set; }
        [Required]
        [MaxLength(10)]
        public string? RelHumidityUoM { get; set; } = "%";
        [Required]
        public DateTime RelHumidityDateTime { get; set; } = DateTime.Now;
    }
}
