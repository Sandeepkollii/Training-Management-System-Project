using CourseWebApi.IRepo;
using CourseWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CourseController : ControllerBase
    {
        ICourseRepository _repo;
        
        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<CourseController>
        [HttpGet]
        [Authorize]
        public IActionResult GetCourses()
        {
            return Ok(_repo.GetCourses());
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            return  Ok(_repo.GetCourseById(id));
        }

        // POST api/<CourseController>
        [HttpPost]
        [Authorize(Roles="admin")]
        public IActionResult Post(Course course)
        {
            _repo.AddCourse(course);
            return Created("course added", course);

        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        [Authorize(Roles ="admin")]

        public IActionResult Put(int id, Course course)
        {
            _repo.UpdateCourse(id, course);
            return Ok();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _repo.DeleteCourse(id);
            return Ok();

        }
    }
}
