using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDES.Models
{
    public class ErrorReportContext : DbContext
    {
        public ErrorReportContext(DbContextOptions<ErrorReportContext> options)
            : base(options)
        {
        }

        public DbSet<ErrorReport> ErrorReports { get; set; }
    }
}
