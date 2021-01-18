using cadastro_restfull.Business.Entities;
using cadastro_restfull.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_restfull.Infraestruture.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseDbContext _context;

        public UserRepository(CourseDbContext context)
        {
            this._context = context;
        }

        public void AddUser(User user)
        {
            _context.User.Add(user);
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }

        public User GetUser(string login)
        {
           return _context.User.FirstOrDefault(u => u.Login == login);
        }

    }
}
