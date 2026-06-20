using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAdmissionSystem.Models;

namespace StudentAdmissionSystem.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly AdmissionDBcontext context;
        public AdmissionController(AdmissionDBcontext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(string status)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var admissions = context.Admissions
                .Include(a => a.Student)
                .Include(a => a.Course)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                admissions = admissions.Where(a => a.Status == status);
            }

            return View(await admissions.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Students = await context.Students.ToListAsync();
            ViewBag.Courses = await context.Courses.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Admission admission)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            // STEP 1: Validate dropdown selection
            if (admission.StuId == 0 || admission.CourseId == 0)
            {
                ModelState.AddModelError("", "Please select both Student and Course");
            }

            // STEP 2: Prevent duplicate admission (same student + same course)
            var exists = context.Admissions.Any(a =>
                a.StuId == admission.StuId &&
                a.CourseId == admission.CourseId);

            if (exists)
            {
                ModelState.AddModelError("", "This student has already applied for this course");
            }

            // STEP 3: COURSE CAPACITY CHECK
            var course = context.Courses.FirstOrDefault(c => c.CourseId == admission.CourseId);

            var currentCount = context.Admissions
                .Count(a => a.CourseId == admission.CourseId && a.Status == "Approved");

            if (course != null && currentCount >= course.Capacity)
            {
                ModelState.AddModelError("", "Course is already full");
            }

            // STEP 4: SAVE IF VALID
            if (ModelState.IsValid)
            {
                admission.Status = "Pending";
                admission.ApplicationDate = DateTime.Now;

                context.Admissions.Add(admission);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            // STEP 5: Reload dropdowns if error occurs
            ViewBag.Students = context.Students.ToList();
            ViewBag.Courses = context.Courses.ToList();

            return View(admission);
        }
        public async Task<IActionResult> Approve(int id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var admission = await context.Admissions.FindAsync(id);

            if (admission != null)
            {
                admission.Status = "Approved";
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Reject(int id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var admission = await context.Admissions.FindAsync(id);

            if (admission != null)
            {
                admission.Status = "Rejected";
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Revert(int id)
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var admission = await context.Admissions.FindAsync(id);

            if (admission != null)
            {
                admission.Status = "Pending";
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}
