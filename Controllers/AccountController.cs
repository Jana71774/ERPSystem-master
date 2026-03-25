using ERPSystem.Models;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Login()
        {
            return View();
        }
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

            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}