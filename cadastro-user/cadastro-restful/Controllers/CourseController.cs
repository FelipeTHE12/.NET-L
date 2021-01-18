using cadastro_restfull.Business.Entities;
using cadastro_restfull.Business.Repositories;
using cadastro_restfull.Models.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cadastro_restfull.Controllers
{
    [Route("api/sonim/course")]
    [ApiController]
    [Authorize]

    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        
        //Sign Course for the authenticated user
        //Return 201, and course data
        [SwaggerResponse(statusCode: 201, description: "Course Registred")]
        [SwaggerResponse(statusCode: 401, description: "Not Authorized")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            Course course = new Course();
            course.Name = courseViewModelInput.Name;
            course.Description = courseViewModelInput.Description;
            var codeUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            course.CodeUser = codeUser;
            _courseRepository.AddCourse(course);
            _courseRepository.Commit();

            
            return Created("", courseViewModelInput);

        }


        [SwaggerResponse(statusCode: 200, description: "Courses Loaded")]
        [SwaggerResponse(statusCode: 401, description: "Not Authorized")]
        [HttpGet]
        [Route("List")]

        public async Task<IActionResult> Get()
        {
                
            var codeUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            
            var courses = _courseRepository.GetByUser(codeUser)
                .Select(d => new CourseViewModelOutput()
                {
                    Name = d.Name,
                    Description = d.Description,
                    Login = d.User.Login
                }
                    );

            return Ok(courses);
        }
    }
}
