using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StudentAdmissionSystem.Models
{
    public class Course
    {
        [Key]
        [ValidateNever]
        public int CourseId { get; set; }  

        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }
        [ValidateNever]
        public string Description { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }
        [ValidateNever]
        public ICollection<Admission> Admissions { get; set; }
    }
}