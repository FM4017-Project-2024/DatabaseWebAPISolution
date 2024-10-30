using Microsoft.EntityFrameworkCore;

namespace DatabaseWebAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<BuildingTemperatureItem> BUILDING_TEMP { get; set; } = null!;
        public DbSet<BuildingRelativeHumidityItem> BUILDING_REL_HUMIDITY { get; set; } = null!;
        public DbSet<BuildingEnergyMeterItem> BUILDING_ENERGY_METER { get; set; } = null!;
        public DbSet<EnergyPredictionItem> ENERGY_PREDICTION { get; set; } = null!;
        public DbSet<WeatherForecastItem> WEATHER_FORECAST { get; set; } = null!;
        public DbSet<WeatherForecastUoMItem> WEATHER_FORECAST_UOM { get; set; } = null!;
    }
}
