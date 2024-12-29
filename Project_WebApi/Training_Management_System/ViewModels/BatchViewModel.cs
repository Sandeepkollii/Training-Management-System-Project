namespace Training_Management_System.ViewModels
{
    public class BatchViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string BatchName { get; set; }
        public int BatchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /// <summary>
        /// number persons can be accomedeated to the batch
        /// </summary>
        public int BatchCount { get; set; }

        public bool IsActive { get; set; }
    }
}
