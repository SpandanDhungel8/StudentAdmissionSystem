using System.ComponentModel.DataAnnotations;
namespace StudentAdmissionSystem.Models
{
    public class Student
    {
        [Key]
        [Required(ErrorMessage="Student Id is required")]
        [Display(Name ="Student Id")] 
       public int StuId { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Student Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        [Display(Name="Email")]
        [Required(ErrorMessage = "Emai is required")]
        [EmailAddress(ErrorMessage="Enter a valid e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please choose Date of Birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
       
    }
}
