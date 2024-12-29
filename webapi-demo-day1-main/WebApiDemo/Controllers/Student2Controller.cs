using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student2Controller : ControllerBase
    {
        static List<Student> list = null;
        public Student2Controller()
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
        public ActionResult<List<Student>> GetStudents()
        {
            if (list.ToList().Count == 0)
                return NotFound();
            return list.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = list.FirstOrDefault(x => x.StudentId == id);
            if (student == null)
                return NotFound();
            else
                return student; 
        }
        [HttpPost]
        public ActionResult<bool> Post(Student student)
        {
            list.Add(student);
            //return Created("Added", student);

            return true;
        }
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, Student student)
        {
             Student temp = list.FirstOrDefault(x => x.StudentId == id);
            if (temp != null)
            {
                temp.Name = student.Name;
                temp.Batch = student.Batch;
                return true;
            }
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            Student temp = list.FirstOrDefault(x => x.StudentId == id);
            if (temp != null)
            {
                list.Remove(temp);
                return 1;
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
