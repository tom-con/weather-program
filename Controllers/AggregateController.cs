using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregateController : Controller
    {

        private WeatherContext _db;
        private WeatherService _ws;
        
        public AggregateController(WeatherContext db, WeatherService ws)
        {
            _db = db;
            _ws = ws;
        }

        // GET api/aggregate
        [HttpGet]
        public ActionResult<string> Get()
        {
            try
            {
                var weatherData = _db.WeatherDatum.ToList();
                var cityData = _ws.AggregateWeatherData(weatherData.ToArray());
                return Json(cityData);
                // foreach(CityAveragedWeatherData city in cityData)
                // {
                //     Console.Write(city);
                //     _db.AveragedDatum.Add(city);
                // }
                // _db.SaveChanges();
                // return "200: Aggregate datapoints successfully added to database: " +
                //     Json(cityData);
            }
            catch (DbUpdateException ex) 
            {
                Console.Write(ex);
                ModelState.AddModelError("", "Unable to add weather datum. " +
                    "This was not explicitly caused by the data format of the " +
                    "POST request");
                return "500: Server error";
            }
        }
    }
}
