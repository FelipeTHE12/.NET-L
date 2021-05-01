using cadastro_restfull.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace cadastro_restfull.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CourseDbContext>
    {
        public CourseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=SONIN;user=sonin;password=f13579");
            CourseDbContext context = new CourseDbContext(optionsBuilder.Options);
            return context;
        }
    }
}
