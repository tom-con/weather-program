using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext (DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public DbSet<Models.WeatherData> WeatherDatum { get; set; }
        public DbSet<Models.CityAveragedWeatherData> AveragedDatum { get; set; }
    }
}