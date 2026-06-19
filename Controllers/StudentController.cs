using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;
using StudentAdmissionSystem.Models;
namespace StudentAdmissionSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly AdmissionDBcontext context;
        public StudentController(AdmissionDBcontext context) {
            this.context = context;
                }
        public async Task<IActionResult> Dashboard()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var students = await context.Students.ToListAsync();

            ViewBag.TotalStudents = students.Count;
            ViewBag.TotalCourses = await context.Courses.CountAsync();
            ViewBag.TotalAdmissions = await context.Admissions.CountAsync();
            return View();
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var students = await context.Students.ToListAsync();

            ViewBag.TotalStudents = students.Count;
            ViewBag.TotalCourses = await context.Courses.CountAsync();
            ViewBag.TotalAdmissions = await context.Admissions.CountAsync();

            return View(students);
        }
        public async Task<IActionResult> Create()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Create(Student student)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                await context.Students.AddAsync(student);
               await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        public async Task<IActionResult>Edit(int? id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id != null)
            {
                var student = await context.Students.FirstOrDefaultAsync(x => x.StuId == id);
                if (student != null)
                {
                    return View(student);
                }
                return NotFound();
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Student student)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id != student.StuId) { return NotFound(); }
            if (ModelState.IsValid) {
                context.Update(student);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Student");
            }
            return View(student);
        }
      
      public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null) { return NotFound(); }
            var student = await context.Students.FirstOrDefaultAsync(x => x.StuId == id);
            if (student == null) { return NotFound(); }
            return View(student);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (id == null) { return NotFound(); }
            var student = context.Students.FirstOrDefault(x => x.StuId == id);
            if (student == null) { return NotFound(); }
            return View(student);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var student = await context.Students.FindAsync(id);
            context.Students.Remove(student);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
