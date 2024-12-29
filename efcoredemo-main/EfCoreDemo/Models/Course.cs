namespace EfCoreDemo.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Duration { get; set; }

        // link with child class
        public IList<Batch>? Batches { get; set; }
    }
}
