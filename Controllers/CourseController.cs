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
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var courses = await context.Courses.Include(c => c.Admissions).ThenInclude(a => a.Student).ToListAsync();
            
            return View(courses);
        }
        public async Task<IActionResult> Create() {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                await context.Courses.AddAsync(course);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
        public async Task<IActionResult> Delete (int? id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null) { return NotFound(); }
            var course = await context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            if (course == null) { return NotFound(); }
            return View(course);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var course = await context.Courses.FindAsync(id);
            if (course == null) { return NotFound(); }

            context.Courses.Remove(course);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
