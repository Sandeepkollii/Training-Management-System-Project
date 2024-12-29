using Project_WebApi.Models;
using Project_WebApi.ViewModels;

namespace Project_WebApi.IRepo
{
    public interface IBatchRepository
    {
        List<Batch> GetBatches();
        
        Batch GetBatchById(int id);
        Batch AddBatch(Batch batch);
        bool UpdateBatch(int id,Batch batch);
        bool DeleteBatch(int id);

        BatchViewModel GetBatchDeatilsById(int id);

        List<BatchViewModel> GetDetails();

        List<CourseViewModel> GetCourseName();

        


    }
    public interface ICourseRepository
    {
        List<Course> GetCourses();
        Course GetCourseById(int id);
        Course AddCourse(Course course);
        bool UpdateCourse(int id,Course course);
        bool DeleteCourse(int id);

        string GetCourseName(string courseName);

    }
    public interface IUserRepository
    {
        List <UserViewModel> GetUsers();
        User GetUserById(int id);
        User AddUser(User user);
        bool UpdateUser(int id,User user);
        bool DeleteUser(int id);

        UserViewModel GetUserDeatilsById(int id);

        List<Role> GetRoles();

        List<UserViewModel> GetManagerNames();

        List<UserViewModel> GetManagers(int id);

        


    }
    public interface IEnrollmentRepository
    {
        List<Enrollment> GetEnrollments();
        Enrollment GetEnrollmentsById(int id);
        Enrollment AddEnrollments(Enrollment enrollment);
        bool UpdateEnrollments(int id,Enrollment enrollment);

        List<EnrollmentViewModel> GetEnrollmentsJoin();


    }
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        

    }
    public interface IFeedbackRepository
    {
        List<Feedback> GetFeedbacks();
        Feedback GetFeedbackById(int id);
        Feedback AddFeedback(Feedback feedback);
        bool UpdateFeedback(int id,Feedback feedback);
        bool DeleteFeedback(int id);

    }
    public interface IAuthenticateRepository
    {
        User AuthenticateUser(LoginViewModel loginViewModel);

        public string GetRoleName(int roleId);
        public List<Role> GetAllRoles();
    }

}
