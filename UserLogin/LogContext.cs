using System.Data.Entity;

namespace UserLogin
{
    public class LogContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
        public LogContext()
            : base(Properties.Settings.Default.DbConnect)
        {

        }
    }
}
