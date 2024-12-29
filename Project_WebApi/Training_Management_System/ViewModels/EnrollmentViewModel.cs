namespace Training_Management_System.ViewModels
{
    public class EnrollmentViewModel
    {

        public int EnrollmentId { get; set; }
        
        public string EnrollmentStatus { get; set; }

        public DateTime RequestDate { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int BatchId { get; set; }
        public int BatchName { get; set; }
    }
}

