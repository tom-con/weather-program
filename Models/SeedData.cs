using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WeatherContext(
                serviceProvider.GetRequiredService<DbContextOptions<WeatherContext>>()))
            {
                // Look for any weather.
                if (context.WeatherDatum.Any())
                {
                    return;   // DB has been seeded
                }

                context.WeatherDatum.AddRange(
                     new WeatherData
                     {
                         State = "CO",
                         City = "Boulder",
                         Date = DateTime.Parse("2018-1-11"),
                         HighTemp = 84.3m,
                         LowTemp = 65.3m
                     },

                     new WeatherData
                     {
                         State = "CO",
                         City = "Boulder",
                         Date = DateTime.Parse("2015-2-22"),
                         HighTemp = 84.3m,
                         LowTemp = 65.3m
                     },

                     new WeatherData
                     {
                         State = "CO",
                         City = "Boulder",
                         Date = DateTime.Parse("2007-9-1"),
                         HighTemp = 84.3m,
                         LowTemp = 65.3m
                     },

                    new WeatherData
                    {
                         State = "IL",
                         City = "Chicago",
                         Date = DateTime.Parse("2010-2-21"),
                         HighTemp = 84.3m,
                         LowTemp = 65.3m
                    },

                     new WeatherData
                     {
                         State = "NY",
                         City = "New York City",
                         Date = DateTime.Parse("2018-8-22"),
                         HighTemp = 84.3m,
                         LowTemp = 65.3m
                     },

                     new WeatherData
                     {
                         State = "MD",
                         City = "Baltimore",
                         Date = DateTime.Parse("2017-4-21"),
                         HighTemp = 84.3m,
                         LowTemp = 65.3m
                     },

                    new WeatherData
                    {
                         State = "NY",
                         City = "New York City",
                         Date = DateTime.Parse("2018-4-17"),
                         HighTemp = 84.3m,
                         LowTemp = 65.3m
                    }
                );
                context.SaveChanges();
            }
        }
    }
}