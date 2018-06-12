using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using Services;
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

        // GET api/cities
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Json(_db.WeatherDatum.ToList());
        }

        // GET api/values/5
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
                return "404: Weather datapoint not found!";
            }
            return Json(weather);
        }

        // POST api/weather
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
