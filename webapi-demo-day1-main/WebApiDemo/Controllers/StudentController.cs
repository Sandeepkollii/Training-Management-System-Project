using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> list = null;
        public StudentController()
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
        public List<Student> GetStudents()
        {
            return list.ToList();
        }

        [HttpGet("{id}")]
        public Student GetStudentById(int id)
        {
            return list.FirstOrDefault(x => x.StudentId == id);
        }
        [HttpPost]
        public void Post(Student student)
        {
            list.Add(student);
        }
        [HttpPut("{id}")]
        public void Put(int id, Student student)
        {
            var temp = GetStudentById(id);
            temp.Name = student.Name;
            temp.Batch = student.Batch;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
                 var temp = GetStudentById(id);
                list.Remove(temp);
        }


        // Web Api is HTTP Service
        // It uses HTTP protocol
        // It used HTTP Verbs for methods
          // HTTPGet , HTTPPost, HttpDelete, HttpPut
    }
}
