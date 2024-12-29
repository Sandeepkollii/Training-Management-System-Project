using CourseWebApi.Models;
using CourseWebApi.ViewModel;
using System.Security.Claims;

namespace CourseWebApi.IRepo
{
    public interface ICourseRepository
    {
        List<Course> GetCourses();
        Course GetCourseById(int id);
        Course AddCourse(Course course);
        bool UpdateCourse(int courseId, Course course);
        bool DeleteCourse(int courseId);
    }

    public interface IBatchRepository
    {
        List<Batch> GetBatches();
        Batch GetBatchById(int id);
        Batch AddBatch(Batch batch);
        bool UpdateBatch(int batchId, Batch batch);
        bool DeleteBatch(int batchId);
        List<CourseViewModel> GetBatchDetails();
    }
    public interface IAuthenticateRepository
    {
        User AuthenticateUser(LoginViewModel loginViewModel);
        public string GetRoleName(int roleId);
        public List<Role> GetAllRoles();
        
}
}
