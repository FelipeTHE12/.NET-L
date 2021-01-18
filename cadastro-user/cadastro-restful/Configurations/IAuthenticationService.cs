using cadastro_restfull.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadastro_restfull.Configurations
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserViewModelOutput userViewModelOutput);
    }
}
