using cadastro_restfull.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_restfull.Business.Repositories
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
        void Commit();
        IList<Course> GetByUser(int codeUser);
        
    }
}
