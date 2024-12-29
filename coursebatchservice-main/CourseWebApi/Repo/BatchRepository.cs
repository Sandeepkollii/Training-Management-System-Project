using CourseWebApi.Context;
using CourseWebApi.IRepo;
using CourseWebApi.Models;
using CourseWebApi.ViewModel;

namespace CourseWebApi.Repo
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
            _dbContext.Batches.Add(batch);
            _dbContext.SaveChanges();
            return batch;
        }

        public bool DeleteBatch(int batchId)
        {
            Batch batch = GetBatchById(batchId);
            if (batch != null)
            {
                _dbContext.Remove(batch);
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
            return _dbContext.Batches.ToList();
        }

        public List<CourseViewModel> GetBatchDetails()
        {
            List<CourseViewModel> batchList = (from x in _dbContext.Batches
                             join y in _dbContext.Courses
                             on x.CousreId equals y.CourseId
                             select new CourseViewModel
                             {
                                  CourseId = x.CousreId,
                                  BatchName = x.BatchName,
                                  CourseName = y.CourseName,
                                  StartDate = x.StartDate

                             }).ToList();
            return  batchList.ToList();
        }
        public bool UpdateBatch(int batchId, Batch batch)
        {
            Batch obj = GetBatchById(batchId);
            if (obj != null)
            {
              obj.StartDate = DateTime.Now;
                obj.BatchName = batch.BatchName;
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
