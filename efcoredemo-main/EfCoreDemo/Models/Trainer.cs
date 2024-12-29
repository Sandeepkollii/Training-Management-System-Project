using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreDemo.Models
{
    public class Trainer
    {
        public int TrainerCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Domain { get; set; }
        public int Exp { get; set; }

        //[ForeignKey("Batch")]
        public int BatchCode { get; set; }
        public Batch? Batch { get; set; }
    }
}
