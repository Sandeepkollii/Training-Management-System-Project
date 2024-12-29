using CourseWebApi.Context;
using CourseWebApi.IRepo;
using CourseWebApi.Models;

namespace CourseWebApi.Repo
{
    public class CourseRepository : ICourseRepository
    {
        AppDbContext _dbContext;
        public CourseRepository(AppDbContext context) {
            
            _dbContext = context;

        }
        public Course AddCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return course;
        }

        public bool DeleteCourse(int courseId)
        {
            Course course = GetCourseById(courseId);
            if (course != null)
            {
                _dbContext.Remove(course);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public Course GetCourseById(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(x => x.CourseId == id);
            return course;
        }  

        public List<Course> GetCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public bool UpdateCourse(int courseId, Course course)
        {
            Course obj = GetCourseById(courseId);
            if (obj != null)
            {
                obj.CourseDetails = course.CourseDetails;
                obj.CourseName = course.CourseName;
          

                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
