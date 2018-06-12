using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {

        private WeatherContext _db;
        
        public WeatherController(WeatherContext db)
        {
            _db = db;
        }

        // GET api/weather
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Json(_db.WeatherDatum.ToList());
        }

        // GET api/weather/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int? id)
        {
            if (id == null)
            {
                return "403: Need ID (int)";
            }
            WeatherData weather = _db.WeatherDatum.Find(id);
            if (weather == null)
            {
                return "404: Weather datapoint not found";
            }
            return Json(weather);
        }

        // POST api/weather
        [HttpPost]
        public ActionResult<string> Post([FromBody] WeatherData weather)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.WeatherDatum.Add(weather);
                    _db.SaveChanges();
                    return "200: Weather datapoint successfully added";
                }
                return "403: Weather datapoint model is not valid";
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

        // PUT api/weather/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int? id, [FromBody] WeatherData weather)
        {
            if(id == null || id != weather.ID)
            {
                return "403: ID needs to match a current valid weather ID. " +
                    "Need ID (int)";
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _db.WeatherDatum.Update(weather);
                    _db.SaveChanges();
                    return "200: Weather datapoint updated successfully";
                }
                catch (DbUpdateException ex)
                {
                    Console.Write(ex);
                    ModelState.AddModelError("", "Unable to update weather datum. " +
                        "This was not explicitly caused by the data format of the " +
                        "PUT request");
                    return "500: Server error";
                }
            }
            return "403: Weather datapoint model is not valid";
        }

        // DELETE api/weather/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int? id)
        {
            if(id == null)
            {
                return "403: Need ID (int)";
            }
            var weatherDatum = _db.WeatherDatum.Find(id);
            if(weatherDatum == null)
            {
                return "403: ID needs to match a current valid weather ID";
            }
            else {
                _db.WeatherDatum.Remove(weatherDatum);
                _db.SaveChanges();
                return "200: Weather datapoint successfully deleted";
            }
        }
    }
}
