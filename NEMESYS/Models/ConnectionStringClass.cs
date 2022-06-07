using Microsoft.EntityFrameworkCore;

namespace NEMESYS.Models
{
    public class ConnectionStringClass : DbContext
    {
        public ConnectionStringClass(DbContextOptions<ConnectionStringClass> options) : base(options)
        {

        }

        public DbSet<ReportClass> Reports { get; set; }
        public DbSet<InvestigationClass> Investigations { get; set; }
}
}
