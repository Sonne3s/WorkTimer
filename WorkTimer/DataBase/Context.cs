using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorkTimer.DataBase
{
    public class Context : DbContext
    {
        public DbSet<WorkingTask> WorkingTasks { get; set; }

        public DbSet<WorkingDay> WorkingDays { get; set; }

        public DbSet<WorkingInterval> WorkingIntervals { get; set; }

        public DbSet<IdleInterval> IdleIntervals { get; set; }

        //public DbSet<WorkingHoursType> WorkingHoursTypes { get; set; }

        public Context()
        {            
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WorkTimer;Trusted_Connection=True;");

            optionsBuilder.LogTo(
                (m) => { System.Diagnostics.Debug.WriteLine(m); },
                LogLevel.Debug,
                DbContextLoggerOptions.UtcTime | DbContextLoggerOptions.SingleLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkingTask>()
                .HasOne(t => t.ParentTask)
                .WithMany(p => p.SubTasks)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkingTask>()
                .Property(t => t.Number)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

            modelBuilder.Entity<WorkingDay>()
                .Property(t => t.Number)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

            modelBuilder.Entity<WorkingInterval>()
                .Property(t => t.Number)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

            modelBuilder.Entity<IdleInterval>()
                .Property(t => t.Number)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
        }
    }
}
