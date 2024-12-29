using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreDemo.Models
{
    [Table("tblStudent")]
    public class Student
    {
        [Key]
        public int RollNo { get; set; }
        [Column("Name", Order =3)]
        [Required]
        public string StudentName { get; set; }
        [Column(Order =2)]
        public string Address { get; set; }
        [Column(Order =5)]
        public string EMail { get; set; }
        [Column(Order =4)]
        public string PhoneNum { get; set; }
        public DateTime DOb { get; set; }
        [NotMapped]
        public int Age { get; set; }
        [ForeignKey("Batch")]
        public int BatchCode { get; set; }
        public Batch? Batch { get; set; }
    }
}
