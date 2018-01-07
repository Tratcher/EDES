using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EDES.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EDES.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        private readonly ErrorReportContext _context;

        public ErrorController(ErrorReportContext context)
        {
            _context = context;

            // Seed
            if (_context.ErrorReports.Count() == 0)
            {
                context.ErrorReports.Add(new ErrorReport() { Created = DateTimeOffset.UtcNow, Message = "some message", Json = "{ stuff }" });
                _context.SaveChanges();
            }
        }

        // GET /error
        [HttpGet]
        public IEnumerable<ErrorReport> Get()
        {
            return _context.ErrorReports.ToList();
        }

        // POST /error
        [HttpPost]
        public IActionResult Post([FromBody]JObject body)
        {
            if (body == null)
            {
                return BadRequest();
            }

            var report = new ErrorReport()
            {
                Created = DateTimeOffset.UtcNow,
                Message = body.GetValue("message").Value<string>(),
                Version = body.GetValue("version").Value<string>(),
                Json = body.GetValue("json").ToString(Formatting.None),
            };

            _context.ErrorReports.Add(report);
            _context.SaveChanges();

            return Ok();
        }
    }
}
