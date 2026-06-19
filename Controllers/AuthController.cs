using Microsoft.AspNetCore.Mvc;
using StudentAdmissionSystem.Models;
using StudentAdmissionSystem.ViewModels;

public class AuthController : Controller
{
    private readonly AdmissionDBcontext context;

    public AuthController(AdmissionDBcontext context)
    {
        this.context = context;
    }

    // LOGIN PAGE
    public IActionResult Login()
    {
        return View();
    }

    // LOGIN POST
    [HttpPost]
    public IActionResult Login(LoginVM vm)
    {
        var user = context.Users
            .FirstOrDefault(u => u.Username == vm.Username && u.Password == vm.Password);

        if (user != null)
        {
            HttpContext.Session.SetString("User", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Dashboard", "Student");
        }

        ViewBag.Error = "Invalid username or password";
        return View(vm);
    }

    // LOGOUT
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}