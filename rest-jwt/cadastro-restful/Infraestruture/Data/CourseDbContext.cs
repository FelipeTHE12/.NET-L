using cadastro_restfull.Business.Entities;
using cadastro_restfull.Infraestruture.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace cadastro_restfull.Infraestruture.Data
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Course> Course { get; set; }
    }

    
}
