using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class EmployeeDbContext : DbContext
    {
        //private readonly IConfiguration _config;
        
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cs = _config.GetConnectionString("DBConnection");
            optionsBuilder.UseSqlServer(cs);
        }*/

        public DbSet<Employee> Employees { get; set; }
    }
}