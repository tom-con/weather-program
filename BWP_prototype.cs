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

        // The "main" of this program. 
        public IEnumerable<CityAveragedWeatherData> AggregateWeatherData(WeatherData[] inputData)
        {
            // Call the method to create a dictionary where cities are separated
            // for ease of averaging later.
            Dictionary<string, List<WeatherData>> byCity = SeparateDataByCity(inputData);


            // Initialize an Array for returning CityAveragedWeatherDatas.
            // Set to length of the dictionary.
            CityAveragedWeatherData[] allCities = new CityAveragedWeatherData[byCity.Count]; 

            // Iterate over dictionary to be able to call average method per
            // individual city.
            int i = 0;
            foreach( KeyValuePair<string, List<WeatherData>> city in byCity ){
                allCities[i] = AverageWeatherData(city.Value);
            }

            return allCities;
        }

        // This method returns a dictionary of datapoints broken out by city
        // when input data is given as an unordered array of weather data points.
        // The dictionary uses unique keys in the format of "city-state" this
        // handles the case for when a city name is shared between two states,
        // such as Washington, which has 88 US cities, or Springfiled, 41 cities.
        public Dictionary<string, List<WeatherData>> SeparateDataByCity(WeatherData[] inputData){

            // Dictionary definition that stores via unique key and a WeatherData
            // List. A list is used because it is dynamically sized.
            Dictionary<string, List<WeatherData>> byCity = new Dictionary<string, List<WeatherData>>();

            // Looping over the WeatherData array to retrieve individual data points.
            foreach(WeatherData dataPoint in inputData){
                // Determining what a data point's unique key would be.
                string uniqueKey = $"{dataPoint.City}-{dataPoint.State}";

                // If the dicitonary contains the key already, add the data point
                // to that key. Else, create the key and instantiate with the 
                // data point.
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

        public CityAveragedWeatherData AverageWeatherData(List<WeatherData> collection){
            // Initialize a new CityAverageWeatherData with city and state and timestamps
            // of the first data point in the collection.
            CityAveragedWeatherData thisCity = new CityAveragedWeatherData();
            thisCity.State = collection[0].State;
            thisCity.City = collection[0].City;
            thisCity.StartDate = collection[0].Date;
            thisCity.EndDate = collection[0].Date;

            // Initialize a count variable to use as a divisor for averaging
            // per iteration step.
            int count = 1;

            // Iterate over each datapoint in the collection and update 
            foreach( WeatherData dataPoint in collection){
                // Update Average High
                if(thisCity.AverageHighTemp == 0)
                    thisCity.AverageHighTemp = dataPoint.HighTemp;
                else
                    thisCity.AverageHighTemp = AveragedTemp(
                        thisCity.AverageHighTemp, dataPoint.HighTemp, count);
            
                // Update Average Low
                if(thisCity.AverageLowTemp == 0)
                    thisCity.AverageLowTemp = dataPoint.LowTemp;
                else
                    thisCity.AverageLowTemp = AveragedTemp(
                        thisCity.AverageLowTemp, dataPoint.LowTemp, count);

                // Update Start Date
                if(thisCity.StartDate > dataPoint.Date)
                    thisCity.StartDate = dataPoint.Date;

                // Update End Date
                if(thisCity.EndDate < dataPoint.Date)
                    thisCity.EndDate = dataPoint.Date;
                
                count += 1;
            }
            return thisCity;
        }

        private decimal AveragedTemp(decimal current, decimal additional, int multiplier){
            decimal multipliedAverage = current * multiplier;
            multipliedAverage += additional;
            return multipliedAverage / (multiplier + 1);
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
