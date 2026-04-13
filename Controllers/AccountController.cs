using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;   // 🔹 added
using System.Threading.Tasks;

namespace ERPSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginService _loginService;

        public AccountController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // LOGIN PAGE
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN POST
[HttpPost]
public async Task<IActionResult> Login(Login model)
{
    if (string.IsNullOrEmpty(model.LoginId) || string.IsNullOrEmpty(model.PasswordHash))
    {
        ViewBag.Error = "Enter LoginId and Password";
        return View();
    }

    var user = await _loginService.ValidateUser(model.LoginId, model.PasswordHash);

    if (user == null)
    {
        ViewBag.Error = "Invalid Login";
        return View();
    }

    // 🔹 SAFE SESSION (fix for ArgumentNullException)
    if (!string.IsNullOrEmpty(user.LoginId))
    {
        HttpContext.Session.SetString("LoginId", user.LoginId);
    }
    else
    {
        ViewBag.Error = "Login failed. LoginId not found.";
        return View();
    }

    return RedirectToAction("Index", "Dashboard");
}

        // LOGOUT
        public IActionResult Logout()
        {
            // 🔹 clear session so sidebar returns to Login
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}