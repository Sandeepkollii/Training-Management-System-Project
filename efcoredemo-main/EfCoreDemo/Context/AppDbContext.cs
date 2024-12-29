using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EfCoreDemo.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext()
        {
            
        }
        // this is DI
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :
            base(dbContextOptions)
        { }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<EfCoreDemo.Models.Course> Course { get; set; } = default!;
        // we were using this method to configure connnectionString
        // was used for conection with database
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    base.OnConfiguring(optionsBuilder);
        //}

        // Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainer>().ToTable("tblTrainer");
            modelBuilder.Entity<Trainer>()
               .Property(s => s.TrainerCode)
               .HasColumnName("TrainerCode")
                
               .IsRequired();
            modelBuilder.Entity<Trainer>()
                .HasKey(s => s.TrainerCode);
            // this is make a property pk

            modelBuilder.Entity<Trainer>()
            .HasOne<Batch>(s => s.Batch)
            .WithMany(g => g.Trainers)
            .HasForeignKey(s => s.BatchCode);

            // batch is parent class
            // trainer is child class
            // 1 batch can be handled by many trainers



        }

    }
}
