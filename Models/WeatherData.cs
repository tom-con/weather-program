using System;

namespace Models 
{
    public class WeatherData 
    {
        public int ID { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public decimal HighTemp { get; set; }
        public decimal LowTemp { get; set; }
    }

}
