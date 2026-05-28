using Microsoft.EntityFrameworkCore;

namespace _02Web_Project.Models
{
    public class EmpDbContext : DbContext
    {
        public DbSet<Emp> Emps { get; set; }

        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) 
        { 
        }
    }
}
