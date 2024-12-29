using CourseWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        // Fluent Api
        // We can use this to seed data / provide some initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Role>()
                .HasData(new Role() { RoleId = 1, RoleName = "admin" },
                 new Role() { RoleId = 2, RoleName = "manager" },
                 new Role() { RoleId = 3, RoleName = "user" }
                );

           
        }

    }
}
