using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAdmissionSystem.Models;

namespace StudentAdmissionSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly AdmissionDBcontext context;
        public CourseController(AdmissionDBcontext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await context.Courses.Include(c => c.Admissions).ThenInclude(a => a.Student).ToListAsync();
            
            return View(courses);
        }
    }
}
