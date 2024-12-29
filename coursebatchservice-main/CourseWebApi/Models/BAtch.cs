namespace CourseWebApi.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public DateTime StartDate { get; set; }

        // this is to add a fk , CourseId becomes FK
        public int CousreId { get; set; }
        public Course? Course { get; set; }
    }
}
