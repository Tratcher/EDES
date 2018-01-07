using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDES.Models
{
    public class ErrorReport
    {
        public long Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Message { get; set; }
        public string Version { get; set; }
        public string Json { get; set; }
    }
}
