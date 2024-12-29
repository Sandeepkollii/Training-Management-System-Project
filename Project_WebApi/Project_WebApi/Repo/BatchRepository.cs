using Project_WebApi.Context;
using Project_WebApi.IRepo;
using Project_WebApi.Models;
using Project_WebApi.ViewModels;

namespace Project_WebApi.Repo
{
    public class BatchRepository : IBatchRepository
    {
        AppDbContext _dbContext;
        public BatchRepository(AppDbContext context)
        {

            _dbContext = context;

        }
        public Batch AddBatch(Batch batch)
        {
            batch.IsActive = true;
            _dbContext.Batches.Add(batch);
            _dbContext.SaveChanges();
            return batch;
        }

        public bool DeleteBatch(int batchId)
        {
            Batch batch = GetBatchById(batchId);
            if (batch != null)
            {
                //_dbContext.Remove(batch);
                batch.IsActive = false;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public Batch GetBatchById(int id)
        {
            var batch = _dbContext.Batches.FirstOrDefault(x => x.BatchId == id);
            return batch;
        }

        public List<Batch> GetBatches()
        {
            return _dbContext.Batches.Where(x=>x.IsActive==true).ToList();
        }

        public bool UpdateBatch(int batchId, Batch batch)
        {
            Batch obj = GetBatchById(batchId);
            if (obj != null)
            {
                obj.StartDate = DateTime.Now;
                obj.EndDate = DateTime.Now;
                obj.BatchCount = batch.BatchCount;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public List<BatchViewModel> GetDetails()
        {
            List<BatchViewModel> batchView = (from x in _dbContext.Batches 
                                              join y in _dbContext.Course 
                                              on x.CourseId equals y.CourseId
                                              where x.IsActive==true
                                              select new BatchViewModel 
                                              { 
                                                  BatchId=x.BatchId,
                                                  BatchName= x.BatchName,
                                                  StartDate= x.StartDate,
                                                  EndDate= x.EndDate,
                                                  CourseName= y.CourseName,
                                                  CourseId = y.CourseId
                                              }).ToList();

            return batchView;

        }
        public List<CourseViewModel> GetCourseName() {

            List<CourseViewModel> courseView = (from x in _dbContext.Course where x.IsActive==true 
                                                select new CourseViewModel
                                                {
                                                    CourseId=x.CourseId,
                                                    CourseName= x.CourseName,
                                                }).ToList();
            return courseView;
        
        }

        public BatchViewModel GetBatchDeatilsById(int id)
        {
            var temp = (from x in _dbContext.Batches
                        join y in _dbContext.Course
                        on x.CourseId equals y.CourseId
                        where x.IsActive == true &&  x.BatchId==id
                        select new BatchViewModel
                        {
                            BatchId = x.BatchId,
                            BatchName = x.BatchName,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            CourseName = y.CourseName,
                            CourseId = y.CourseId
                        }).FirstOrDefault();
            return temp;
            
        }

        
    }
}
