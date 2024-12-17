using Microsoft.EntityFrameworkCore;
using RepoPatternDemo.Models;

namespace RepoPatternDemo.Context
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext() {  }
        public EmpDbContext(DbContextOptions<EmpDbContext> dbContextOptions)
            : base (dbContextOptions) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
