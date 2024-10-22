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
    }
}
