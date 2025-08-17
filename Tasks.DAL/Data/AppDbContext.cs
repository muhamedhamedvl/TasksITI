using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Models;

namespace Tasks.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    Id = 1,
                    FirstName = "Ali",
                    LastName = "Hassan",
                    Bio = "Expert in C#",
                    Specialization = Specialization.SoftwareDevelopment,
                    IsActive = true
                },
                new Instructor
                {
                    Id = 2,
                    FirstName = "Sara",
                    LastName = "Ahmed",
                    Bio = "Frontend Developer",
                    Specialization = Specialization.SoftwareDevelopment,
                    IsActive = true
                },
                new Instructor
                {
                    Id = 3,
                    FirstName = "Omar",
                    LastName = "Khaled",
                    Bio = "Full Stack Developer",
                    Specialization = Specialization.SoftwareDevelopment,
                    IsActive = true
                }
            );
        }
    }
}
