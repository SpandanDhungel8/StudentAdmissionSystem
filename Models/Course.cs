using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StudentAdmissionSystem.Models
 
{
    public class Course
    {
        [Key]
        [Required(ErrorMessage="Course Id is required")]
        public int CourseId { get; set; }
        [Required(ErrorMessage="Course Name is required")]
        public string CourseName { get; set; }

        public string Description { get; set; }
        
        public int Capacity { get; set; }
        public ICollection<Admission> Admissions { get; set; }
    }
}
