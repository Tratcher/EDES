using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EDES.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        // GET error
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
