using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_WebApi.IRepo;
using Project_WebApi.Models;

namespace Project_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CourseController : ControllerBase
    {
        ICourseRepository _courseRepo;
        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(_courseRepo.GetCourses());
        }

        // GET api/<BatchController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            return Ok(_courseRepo.GetCourseById(id));
        }

        // POST api/<BatchController>
        [HttpPost]
        [Authorize(Roles = "admin")]

        public  ActionResult  Post(Course course)
        {
            //string courseName = _courseRepo.GetCourseName(course.CourseName);
            //if (courseName != null)
            //{
            //    return BadRequest("already exists");
            //}
            //else
            //{
                 _courseRepo.AddCourse(course);
                return Created("Course Created", course);
            //}
        }
        // PUT api/<BatchController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(int id, Course course)
        {
            _courseRepo.UpdateCourse(id, course);
            return Ok();
        }

        // DELETE api/<BatchController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _courseRepo.DeleteCourse(id);
            return Ok();
        }

    }
}
