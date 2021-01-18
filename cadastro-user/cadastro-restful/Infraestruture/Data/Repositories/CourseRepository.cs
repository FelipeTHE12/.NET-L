using cadastro_restfull.Business.Entities;
using cadastro_restfull.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_restfull.Infraestruture.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;

        public CourseRepository(CourseDbContext context)
        {
            _context = context;
        }

        public void AddCourse(Course course)
        {
            _context.Course.Add(course);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Course> GetByUser(int codeUser)
        {
            return _context.Course.Include(i => i.User).Where(w => w.CodeUser == codeUser).ToList();
        }
    }
}
