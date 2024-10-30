using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseWebAPI.Models
{
    public class WeatherForecastItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;

        [Required]
        public DateTime ForecastTime { get; set; }

        [Required]
        public float Temperature { get; set; }

        [Required]
        public float WindDirection { get; set; }

        [Required]
        public float Humidity { get; set; }

        [Required]
        public float Pressure { get; set; }

        [Required]
        public float Cloudiness { get; set; }

        [Required]
        public float LowClouds { get; set; }

        [Required]
        public float MediumClouds { get; set; }

        [Required]
        public float HighClouds { get; set; }

        [Required]
        public float DewpointTemperature { get; set; }
    }
}
