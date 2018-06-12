using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {

        private WeatherContext _db;
        
        public CitiesController(WeatherContext db)
        {
            _db = db;
        }

        // GET api/cities
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Json(_db.AveragedDatum.ToList());
        }

        // GET api/cities/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int? id)
        {
            if (id == null)
            {
                return "403: Need ID (int)";
            }
            CityAveragedWeatherData city = _db.AveragedDatum.Find(id);
            if (city == null)
            {
                return "404: City datapoint not found";
            }
            return Json(city);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<string> Post([FromBody] CityAveragedWeatherData city)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _db.AveragedDatum.Add(city);
                    _db.SaveChanges();
                    return "200: City datapoint successfully added";
                }
                return "403: City datapoint model is not valid";
            }
            catch (DbUpdateException ex) 
            {
                Console.Write(ex);
                ModelState.AddModelError("", "Unable to add city datum. " +
                    "This was not explicitly caused by the data format of the " +
                    "POST request");
                return "500: Server error";
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int? id, [FromBody] CityAveragedWeatherData city)
        {
            if(id == null || id != city.ID)
            {
                return "403: ID needs to match a current valid city ID. " +
                    "Need ID (int)";
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _db.AveragedDatum.Update(city);
                    _db.SaveChanges();
                    return "200: City datapoint updated successfully";
                }
                catch (DbUpdateException ex)
                {
                    Console.Write(ex);
                    ModelState.AddModelError("", "Unable to update city datum. " +
                        "This was not explicitly caused by the data format of the " +
                        "PUT request");
                    return "500: Server error";
                }
            }
            return "403: City datapoint model is not valid";
        }

        // DELETE api/values/5
        public ActionResult<string> Delete(int? id)
        {
            if(id == null)
            {
                return "403: Need ID (int)";
            }
            var averagedDatum = _db.AveragedDatum.Find(id);
            if(averagedDatum == null)
            {
                return "403: ID needs to match a current valid city ID";
            }
            else {
                _db.AveragedDatum.Remove(averagedDatum);
                _db.SaveChanges();
                return "200: City datapoint successfully deleted";
            }
        }
    }
}
