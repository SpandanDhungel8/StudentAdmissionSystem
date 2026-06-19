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
        public async Task<IActionResult> Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
               await context.Courses.AddAsync(course);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
    }
}
