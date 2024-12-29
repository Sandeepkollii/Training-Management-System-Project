namespace EfCoreDemo.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string Desc { get; set; }
        public string? BatchName { get; set; }
        public DateTime StartDate { get; set; }
        public int Seats { get; set; }
        public string TrainerName { get; set; }

        // adding fk
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        // adding link for student class
        public IList<Student>? Students { get; set; }

        public IList<Trainer>? Trainers { get; set; }



    }
}
