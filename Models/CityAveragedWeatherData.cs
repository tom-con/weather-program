using System;

namespace Models 
{

    public class CityAveragedWeatherData 
    {
        public int ID { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public decimal AverageHighTemp { get; set; }
        public decimal AverageLowTemp { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }  

}
