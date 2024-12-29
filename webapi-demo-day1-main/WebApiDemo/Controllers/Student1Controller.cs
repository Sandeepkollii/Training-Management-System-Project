using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student1Controller : ControllerBase
    {
        static List<Student> list = null;
        public Student1Controller()
        {
            if (list == null)
            {
                list = new List<Student>()
                {
               new Student() { StudentId=1, Name="Ajay" , Batch="B001", Marks=89, DateOfBirth=Convert.ToDateTime("12/12/2020")},

               new Student() { StudentId=2, Name="Deepak" , Batch="B002", Marks=78, DateOfBirth=Convert.ToDateTime("10/06/2020")},


                };
            }
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            if (list.ToList().Count == 0)
                return NotFound();
            return Ok(list.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = list.FirstOrDefault(x => x.StudentId == id);
            if (student == null)
                return NotFound();
            else
                return Ok(student); 
        }
        [HttpPost]
        public IActionResult Post(Student student)
        {
            list.Add(student);
            return Created("Added", student);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
             Student temp = list.FirstOrDefault(x => x.StudentId == id);
            if (temp != null)
            {
                temp.Name = student.Name;
                temp.Batch = student.Batch;
                return Ok(temp);
            }
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student temp = list.FirstOrDefault(x => x.StudentId == id);
            if (temp != null)
            {
                list.Remove(temp);
                return Ok(temp);
            }
            else
                return NotFound();
        }


        // Web Api is HTTP Service
        // It uses HTTP protocol
        // It used HTTP Verbs for methods
          // HTTPGet , HTTPPost, HttpDelete, HttpPut
    }
}
