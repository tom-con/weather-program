using System;
using System.Collections.Generic;

namespace weather_program
{
    //We are compiling a report on the average temperatures among various cities over each month. 
    //We receive individual daily data points from a weather service. 
    //Given a collection of data points over a given month, average the data into the requested format for easier reporting.
	
	//Please include tests in the testing framework you are most comfortable with.
	
	//We prefer your completed work in a Git repo.
   
    public class WeatherService2
    {

        public IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData)
        {
            Dictionary<string, List<WeatherData>> byCity = SeparateDataByCity(inputData);
            List<CityAveragedWeatherData> averagePerCity = new List<CityAveragedWeatherData>();
            foreach( WeatherData dataPoint in inputData ){
                
                count += 1;
            }

            return averageSingleCity;
        }

        public Dictionary<string, List<WeatherData>> SeparateDataByCity(WeatherData[] inputData){
            Dictionary<string, List<WeatherData>> byCity = new Dictionary<string, List<WeatherData>>();
            foreach(WeatherData dataPoint in inputData){
                string uniqueKey = $"{dataPoint.City}-{dataPoint.State}";
                if(byCity.ContainsKey(uniqueKey)) {
                    byCity[uniqueKey].Add(dataPoint);
                } else {
                    List<WeatherData> thisCity = new List<WeatherData>();
                    thisCity.Add(dataPoint);
                    byCity.Add(uniqueKey, thisCity);
                }
            }

            return byCity;
        }

    }
    
    public class WeatherData 
    {
        public string State { get; set; }
        public string City { get; set; }
        public DateTime Date { get; set; }
        public decimal HighTemp { get; set; }
        public decimal LowTemp { get; set; }
    }
        
    public class CityAveragedWeatherData 
    {
        public string State { get; set; }
        public string City { get; set; }
        public decimal AverageHighTemp { get; set; }
        public decimal AverageLowTemp { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }    
}
