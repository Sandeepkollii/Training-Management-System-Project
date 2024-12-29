using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;
using Project_WebApi.ViewModels;

namespace Project_WebApi.Repo
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        AppDbContext _dbContext;
        public EnrollmentRepository(AppDbContext context)
        {

            _dbContext = context;

        }

        public List<EnrollmentViewModel> GetEnrollmentsJoin()
        {
            List<EnrollmentViewModel> views = (from x in _dbContext.Enrollments
                                               join y in _dbContext.Users on x.UserId equals y.UserId
                                               join z in _dbContext.Batches on x.BatchId equals z.BatchId
                                               select new EnrollmentViewModel 
                                               { 
                                                   EnrollmentId = x.EnrollmentId,
                                                   UserId = x.UserId,
                                                   UserName = y.UserName,
                                                   BatchId = z.BatchId,
                                                   BatchName = z.BatchName,
                                                   EnrollmentStatus = x.EnrollmenStatus,
                                                   RequestDate = x.RequestDate,

                                               }).ToList();
            return views;
        }

        public List<Enrollment> GetEnrollments()
        {
            return _dbContext.Enrollments.Where(x=>x.IsActive==true).ToList();
        }
        public Enrollment AddEnrollments(Enrollment enrollment)
        {
            enrollment.IsActive = true;
            _dbContext.Enrollments.Add(enrollment);
            _dbContext.SaveChanges();
            return enrollment;
        }

        public bool DeleteEnrollments(int EnrollmentId)
        {
            Enrollment enrollment = GetEnrollmentsById(EnrollmentId);
            if (enrollment != null)
            {
                enrollment.IsActive = false;
                //_dbContext.Remove(enrollment);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public Enrollment GetEnrollmentsById(int id)
        {
            var enrollment = _dbContext.Enrollments.FirstOrDefault(x => x.BatchId == id && x.IsActive==true);
            return enrollment;


        }


        public bool UpdateEnrollments(int EnrollmentId, Enrollment enrollment)
        {
            Enrollment obj = GetEnrollmentsById(EnrollmentId);
            if (obj != null)
            {
                obj.EnrollmenStatus = enrollment.EnrollmenStatus;
                obj.RequestDate = DateTime.Now;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }


    }
}
