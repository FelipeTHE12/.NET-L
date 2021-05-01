using cadastro_restfull.Business.Entities;
using cadastro_restfull.Business.Repository;
using cadastro_restfull.Configurations;
using cadastro_restfull.Filters;
using cadastro_restfull.Infraestruture.Data;
using cadastro_restfull.Models;
using cadastro_restfull.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace cadastro_restfull.Controllers
{
    [Route("/api/sonim/User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserController(IUserRepository userRepository,
            IConfiguration configuration,
            IAuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        [SwaggerResponse(statusCode: 200, description: "Autentication Sucess", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required Fields", Type = typeof(FieldValidationViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal Error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("Login")]
        [ModelStateValidationCustom]

        //Cadastred user authentication.
        //Returns Ok, user data and JWT Token
        // Parameter = "loginViewModelInput"
        public IActionResult Login(LoginViewModelInput loginViewModelInput)
        {

            User user = _userRepository.GetUser(loginViewModelInput.Login);

            if (user == null)
            {
                return BadRequest("Got an error when trying to acess.");
            }

            var userViewModelOutput = new UserViewModelOutput()
            {
                Code = user.Code,
                Login = user.Password,
                Email = user.Email
            };

            var token = _authenticationService.GenerateToken(userViewModelOutput);

            return Ok(new { 
                Token = token,
                User = userViewModelOutput
            });
        }


        [SwaggerResponse(statusCode: 200, description: "Autentication Sucess", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Required Fields", Type = typeof(FieldValidationViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Internal Error", Type = typeof(GenericErrorViewModel))]
        [HttpPost]
        [Route("SignIn")]

        //Sign in a new User, if not already registred
        // Parameter = "signViewModelInput"
        public IActionResult SignUser(SignViewModelInput signViewModelInput)
        {
            var user = new User();
            user.Login = signViewModelInput.Login;
            user.Password = signViewModelInput.Password;
            user.Email = signViewModelInput.Email;


            _userRepository.AddUser(user);
            _userRepository.Commit();
            

            return Created("", user);
        }

    }
}
