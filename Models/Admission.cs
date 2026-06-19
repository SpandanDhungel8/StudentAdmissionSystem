using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace StudentAdmissionSystem.Models
{
    public class Admission
    {
        [Key]
            public int AdmissionId { get; set; }
        [ForeignKey ("Student")]   
        public int? StuId { get; set; }
        [ForeignKey(nameof(StuId))]
        [ValidateNever]
        public Student Student { get; set; }
        [ForeignKey ("Course")]
            public int? CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        [ValidateNever]
        public Course Course { get; set; }
            public DateTime ApplicationDate { get; set; } = DateTime.Now;
            public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
       
    }
}
