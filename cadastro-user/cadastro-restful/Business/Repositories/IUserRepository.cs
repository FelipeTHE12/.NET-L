using cadastro_restfull.Business.Entities;
using cadastro_restfull.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_restfull.Business.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);

        void Commit();

        public User GetUser(string login);
        
    }
}
