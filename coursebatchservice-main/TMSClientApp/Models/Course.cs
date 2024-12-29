namespace TMSClientApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDetails { get; set; }

        // this is to link Batch Class
        public List<Batch>? Batches { get; set; }
    }
}
