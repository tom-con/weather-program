using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggregateController : Controller
    {

        private WeatherContext _db;
        
        public AggregateController(WeatherContext db)
        {
            _db = db;
        }

        // POST api/weather
        [HttpPost]
        public void Post([FromBody] string value)
        {
            
        }

    }
}