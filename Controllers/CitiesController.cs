using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
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
