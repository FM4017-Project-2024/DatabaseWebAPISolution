using System.ComponentModel.DataAnnotations;

namespace DatabaseWebAPI.Models
{
    public class WeatherForecastUoMItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Attribute { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string UoM { get; set; } = string.Empty;
    }
}
