using cadastro_restfull.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace cadastro_restfull.Configurations
{
    public class JwtService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserViewModelOutput userViewModelOutput)
        {
            var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Code.ToString()),
                    new Claim(ClaimTypes.Name, userViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, userViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenarated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenarated);


            return token;
        }
    }
}
