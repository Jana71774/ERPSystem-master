using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}