using System.Data.Entity;

namespace StudentInfoSystem
{
    public class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentInfoContext()
            : base(Properties.Settings.Default.DbConnect)
        { }
    }
}
